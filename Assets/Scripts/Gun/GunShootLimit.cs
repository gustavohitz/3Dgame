using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GunShootLimit : GunBase {

    public List<UIFillUpdater> uIGunUpdaters;

    public float maxShots = 5f;
    public float timeToReload = 1f;

    private float _currentShots;
    private bool _reloading = false;

    void Awake() {
        GetAllUIs();
    }

    protected override IEnumerator ShootCoroutine() {
        if(_reloading) yield break;

        while(true) {
            if(_currentShots < maxShots) {
                Shoot();
                _currentShots++;
                CheckReload();
                UpdateUI();
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }
    }
    private void CheckReload() {
        if(_currentShots >= maxShots) {
            StopShoot();
            StartReload();
        }
    }
    private void StartReload() {
        _reloading = true;
        StartCoroutine(ReloadCoroutine());
    }
    IEnumerator ReloadCoroutine() {
        float time = 0;
        while(time < timeToReload) {
            time += Time.deltaTime;
            uIGunUpdaters.ForEach(i => i.UpdateValue(time / timeToReload));
            yield return new WaitForEndOfFrame();
        }
        _currentShots = 0;
        _reloading = false;
    }

    private void UpdateUI() {
        uIGunUpdaters.ForEach(i => i.UpdateValue(maxShots, _currentShots));
    }
    private void GetAllUIs() {
        uIGunUpdaters = GameObject.FindObjectsOfType<UIFillUpdater>().ToList();
    }
  
}
