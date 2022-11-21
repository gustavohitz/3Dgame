using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayLevel : MonoBehaviour {
    public TextMeshProUGUI uiTextName;

    void Start() {
        SaveManager.Instance.LoadedFile += OnLoad;
    }
    public void OnLoad(SaveSetup setup) {
        uiTextName.text = "Load" /*+ (setup.lastLevel + 1)*/;
    }
    private void OnDestroy() {
        SaveManager.Instance.LoadedFile -= OnLoad;
    }
}
