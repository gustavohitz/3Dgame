using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityBase : MonoBehaviour {

    protected Player player;
    protected Inputs inputs;

    void OnValidate() {
        if(player == null) {
            player = GetComponent<Player>();
        }
    }

    void Start() {
        inputs = new Inputs();
        inputs.Enable();

        Init();
        OnValidate();
        RegisterListeners();
    }
    void OnEnable() {
        if(inputs != null) {
            inputs.Enable();
        }
    }

    void OnDisable() {
        inputs.Disable();
    }

    void OnDestroy() {
        RemoveListeners();
    }

    protected virtual void Init() {

    }
    protected virtual void RegisterListeners() {
        
    }
    protected virtual void RemoveListeners() {
        
    }
  
}
