using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {//, IDamageable
    public List<Collider> colliders;
    public Animator animator;
    public CharacterController characterController;
    public float speed = 1f;
    public float rotationSpeed = 1f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15f;
    
    [Header("Run Setup")]
    public KeyCode runKey = KeyCode.LeftShift;
    public float runningSpeed = 1.5f;

    private float _vSpeed = 0f;
    private bool _alive = true;
    
    [Header("Flash")]
    public List<FlashColor> flashColors;

    [Header("Life")]
    public HealthBase healthBase;
    public UIFillUpdater uiGunUpdater;

    private Renderer[] renderers;
    public Renderer[] Renderers {
        get {
            return renderers;
        }
    }

    void Awake() {
        renderers = transform.GetComponentsInChildren<Renderer>();
        OnValidate();
        healthBase.OnDamage += Damage;
        healthBase.OnKill += OnKill;
    }

    void Update() {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        var inputVerticalAxis = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputVerticalAxis * speed;

        if(characterController.isGrounded) {
            _vSpeed = 0;
           if(Input.GetKeyDown(KeyCode.Space)) {
                _vSpeed = jumpSpeed;
            }
        }

        var isWalking = inputVerticalAxis != 0;
        if(isWalking) {
            if(Input.GetKey(runKey)) {
                speedVector *= runningSpeed;
                animator.speed = runningSpeed;
            }
            else {
                animator.speed = 1;
            }
        }


        _vSpeed -= gravity * Time.deltaTime;
        speedVector.y = _vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }

    void OnValidate() {
        if(healthBase == null) {
            healthBase = GetComponent<HealthBase>();
        }
    }

    [NaughtyAttributes.Button]
    public void Respawn() {
        if(CheckpointManager.Instance.HasCheckpoint()) {
            transform.position = CheckpointManager.Instance.GetPositionFromLastCheckPoint();
        }
    }

    #region LIFE
    public void Damage(HealthBase h) {
        flashColors.ForEach(i => i.Flash());
    }
    public void Damage(float damage, Vector3 dir) {
        //Damage(damage);
    }
    private void OnKill(HealthBase h) {
        if(_alive) {
            _alive = false;
            animator.SetTrigger("Death");
            colliders.ForEach(i => i.enabled = false);

            Invoke(nameof(Revive), 3f);
        }
    }
    private void Revive() {
        _alive = true;
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        Respawn();
        Invoke(nameof(TurnOnColliders), .1f);
        
    }
    private void TurnOnColliders() {
        colliders.ForEach(i => i.enabled = true);
    }
    #endregion
  
}
