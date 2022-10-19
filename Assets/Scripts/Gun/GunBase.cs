using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GunBase : MonoBehaviour {

    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShots = .3f;

    private Coroutine _currentCoroutine;


    IEnumerator ShootCoroutine() {
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
    public void StartShoot() {
        StopShoot();
        _currentCoroutine = StartCoroutine(ShootCoroutine());
    }
    public void StopShoot() {
        if(_currentCoroutine != null) {
            StopCoroutine(_currentCoroutine);
        }
    }
    
}
