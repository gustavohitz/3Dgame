using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour {

    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Header("Setup")]
    public Color color = Color.red;
    public float duration = .1f;

    //private Color defaultColor;
    private Tween _currentTween;

   /*void Start() {
        defaultColor = meshRenderer.material.GetColor("_EmissionColor");
    }*/
    void OnValidate() {
        if(meshRenderer == null) {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        if(skinnedMeshRenderer == null) {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }
    }

    [NaughtyAttributes.Button]
    public void Flash() {
        if(meshRenderer != null && !_currentTween.IsActive()) {
            _currentTween = meshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
        }
        if(skinnedMeshRenderer != null && !_currentTween.IsActive()) {
            _currentTween = skinnedMeshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}

 
