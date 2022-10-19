using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GunBase : MonoBehaviour {

    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShots = .3f;

    private Coroutine _currentCoroutine;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Z)) {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if(Input.GetKeyUp(KeyCode.Z)) {
            if(_currentCoroutine != null) {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot() {
        while(true) {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    public void Shoot() {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
    }
    
}
