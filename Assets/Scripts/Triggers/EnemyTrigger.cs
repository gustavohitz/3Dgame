using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class EnemyTrigger : MonoBehaviour {

    public GameObject enemy;
    public string tagToCheck = "Player";

    void Awake() {
        enemy.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(tagToCheck)) {
            enemy.SetActive(true);
            enemy.GetComponent<EnemyShoot>().StartShoot();
        }
    }
   
}
