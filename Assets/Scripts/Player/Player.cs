using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
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
  
}
