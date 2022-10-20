using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGunUpdater : MonoBehaviour {

    public Image UIImage;
    [Header("Animation")]
    public float duration = .1f;
    public Ease ease = Ease.Linear;

    private Tween _currentTween;

    void OnValidate() {
        if(UIImage == null) {
            UIImage = GetComponent<Image>();
        }
    }
    public void UpdateValue(float f) {
        UIImage.fillAmount = f;
    }
    public void UpdateValue(float max, float current) {
        if(_currentTween != null) {
            _currentTween.Kill();
        }
        _currentTween = UIImage.DOFillAmount(1 - (current / max), duration).SetEase(ease);
    }
    
}
