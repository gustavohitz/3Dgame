using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartCheck : MonoBehaviour {

    public string tagToCheck = "Player";
    public GameObject bossCamera;
    public Color gizmoColor = Color.yellow;

    void Awake() {
        bossCamera.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if(other.transform.tag == tagToCheck) {
            TurnCameraOn();
        }
    }

    void TurnCameraOn() {
        bossCamera.SetActive(true);
    }

    void OnDrawGizmos() {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, transform.localScale.y);
    }
    
}
