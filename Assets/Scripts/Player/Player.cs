using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator animator;
    public CharacterController characterController;
    public float speed = 1f;
    public float rotationSpeed = 1f;
    public float gravity = -9.8f;

    private float _vSpeed = 0f;

    void Update() {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        var inputVerticalAxis = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputVerticalAxis * speed;

        _vSpeed -= gravity * Time.deltaTime;
        speedVector.y = _vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        if(inputVerticalAxis != 0) {
            animator.SetBool("Run", true);
        }
        else {
            animator.SetBool("Run", false);
        }
    }
  
}
