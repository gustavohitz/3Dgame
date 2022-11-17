using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase {


    public GunBase gunBase;
    public GunShootLimit gunShootLimit;
    public Transform gunPosition;
    public FlashColor flashColor;
    
    private GunBase _currentGun;
    private GunBase _gunBaseInstance;
    private GunBase _gunShootLimiteInstance;



    protected override void Init() {
        base.Init();

        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();

        inputs.Gameplay.ChangeGun1.performed += ctx => ChangeGun1();
        inputs.Gameplay.ChangeGun2.performed += ctx => ChangeGun2();
    }
    private void CreateGun() {
        _gunBaseInstance = Instantiate(gunBase, gunPosition);
        _gunBaseInstance.transform.localPosition = Vector3.zero;
        _gunBaseInstance.transform.localEulerAngles = Vector3.zero;

        _gunShootLimiteInstance = Instantiate(gunShootLimit, gunPosition);
        _gunShootLimiteInstance.transform.localPosition = Vector3.zero;
        _gunShootLimiteInstance.transform.localEulerAngles = Vector3.zero;
        _gunShootLimiteInstance.gameObject.SetActive(false);

        _currentGun = _gunBaseInstance;
    }
    private void ChangeGun1() {
        if(_currentGun != _gunBaseInstance) {
            _currentGun.gameObject.SetActive(false);
            _currentGun = _gunBaseInstance;
            _currentGun.gameObject.SetActive(true);
        }
    }
    private void ChangeGun2() {
        if(_currentGun != _gunShootLimiteInstance) {
            _currentGun.gameObject.SetActive(false);
            _currentGun = _gunShootLimiteInstance;
            _currentGun.gameObject.SetActive(true);
        }
    }
    
    private void StartShoot() {
        _currentGun.StartShoot();
        flashColor?.Flash();
        Debug.Log("Start Shoot");
    }
    private void CancelShoot() {
        _currentGun.StopShoot();
        Debug.Log("Cancel Shoot");
    }

}
