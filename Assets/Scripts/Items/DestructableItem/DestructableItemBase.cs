using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour {
    public HealthBase healthBase;
    public float shakeDuration = .1f;
    public int shakeVibrato = 5;

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
    }
}
