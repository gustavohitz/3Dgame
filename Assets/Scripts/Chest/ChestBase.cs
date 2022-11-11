using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour {
    public KeyCode keyCode = KeyCode.E;
    public Animator animator;
    public string triggerOpen = "Open";

    [Space]
    public ChestItemBase chestItem;

    [Header("Notification")]
    public GameObject notification;
    public float tweenDuration = .2f;
    public Ease tweenEase = Ease.OutBack;
    private float _startScale;

    private bool _chestOpen = false;

    void Start() {
        _startScale = notification.transform.localScale.x;
        HideNotification();
    }
    void Update() {
        if(Input.GetKeyDown(keyCode) && notification.activeSelf) {
            OpenChest();
        }
    }

    [NaughtyAttributes.Button]
    private void OpenChest() {
        if(_chestOpen) return;

        animator.SetTrigger(triggerOpen);
        _chestOpen = true;
        HideNotification();
        Invoke(nameof(ShowItem), 1f);
    }
    private void ShowItem() {
        chestItem.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }
    private void CollectItem() {
        chestItem.Collect();
    }
    void OnTriggerEnter(Collider other) {
        Player p = other.transform.GetComponent<Player>();
        if(p != null) {
            ShowNotification();
        }
    }
    void OnTriggerExit(Collider other) {
        Player p = other.transform.GetComponent<Player>();
        if(p != null) {
            HideNotification();
        }
    }
    
    [NaughtyAttributes.Button]
    void ShowNotification() {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(_startScale, tweenDuration);
    }
    
    [NaughtyAttributes.Button]
    void HideNotification() {
        notification.SetActive(false);
    }
    
}
