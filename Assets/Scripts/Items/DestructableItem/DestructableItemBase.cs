using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour {
    public HealthBase healthBase;
    public float shakeDuration = .1f;
    public int shakeVibrato = 5;
    public int dropCoinsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;

    void OnValidate() {
        if(healthBase == null) {
            healthBase = GetComponent<HealthBase>();
        }
    }
    void Awake() {
        OnValidate();
        healthBase.OnDamage += OnDamage;
    }
    void OnDamage(HealthBase h) {
        transform.DOShakeScale(shakeDuration, Vector3.up/2, shakeVibrato);
        DropGroupOfCoins();
    }

    [NaughtyAttributes.Button]
    void DropCoins() {
        var i = Instantiate(coinPrefab);
        i.transform.position = dropPosition.position;
        i.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From();
    }

    [NaughtyAttributes.Button]
    void DropGroupOfCoins() {
        StartCoroutine(DropGroupOfCoinsCoroutine());
    }
    IEnumerator DropGroupOfCoinsCoroutine() {
        for(int i = 0; i < dropCoinsAmount; i++) {
            DropCoins();
            yield return new WaitForSeconds(.1f);
        }
    }
}
