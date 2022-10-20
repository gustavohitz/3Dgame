using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour {

    public KeyCode gunOne = KeyCode.Keypad1;
    public KeyCode gunTwo = KeyCode.Keypad2;

    public GameObject prefabGunOne;
    public GameObject prefabGunTwo;

    private void Start() {
        prefabGunOne.SetActive(true);
        prefabGunTwo.SetActive(false);
    }
    private void Update() {
        SwitchGun();
    }

    private void SwitchGun() {
        if(Input.GetKeyDown(gunOne)) {
            prefabGunOne.SetActive(true);
            prefabGunTwo.SetActive(false);
        }
        else if(Input.GetKeyDown(gunTwo)) {
            prefabGunOne.SetActive(false);
            prefabGunTwo.SetActive(true);
        }
    }
 
}
