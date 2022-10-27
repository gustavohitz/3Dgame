using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMessageBase : MonoBehaviour {

    public TextMeshProUGUI message;
    public float timeToHide = 2f;

    void Awake() {
        HideMessage();
    }

    public void ShowMessage() {
        message.enabled = true;
        StartCoroutine(HideText());
    }
    public void HideMessage() {
        message.enabled = false;
    }
    IEnumerator HideText() {
        yield return new WaitForSeconds(timeToHide);
        HideMessage();
    }
   
}
