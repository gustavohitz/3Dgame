using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour {

    public MeshRenderer meshRenderer;
    public int key = 01;

    private string checkpointKey = "CheckpointKey";
    private bool checkpointActivated = false;

    void OnTriggerEnter(Collider other) {
        if(!checkpointActivated && other.transform.tag == "Player") {
            VerifyCheckpoint();
        }
    }

    void VerifyCheckpoint() {
        TurnCheckpointOn();
        SaveCheckpoint();
    }

    [NaughtyAttributes.Button]
    void TurnCheckpointOn() {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }

    void TurnCheckpointOff() {
        meshRenderer.material.SetColor("_EmissionColor", Color.gray);
    }
    void SaveCheckpoint() {
        if(PlayerPrefs.GetInt(checkpointKey, 0) > key) {
            PlayerPrefs.SetInt(checkpointKey, key);

            checkpointActivated = true;
        }
    }
}


