using System.Collections;
using System.Collections.Generic;
using Movement;
using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputDetector inputDetector;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallForce;
    [SerializeField] private float minFallSpeed;
    [SerializeField] private float velPower;
    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;
    
    private bool facingRight;

    private Rigidbody2D rbody;

    public bool FacingRight { get => facingRight; }
    public Rigidbody2D Rbody { get => rbody; }

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        inputDetector = FindAnyObjectByType<InputDetector>();
    }

    private bool IsGrounded() {
        return GetComponent<Rigidbody2D>().linearVelocity.y == 0;
    }


    
    private void FixedUpdate() {
        if(inputDetector.Movement().x != 0) {
            HorizontalMovement.Run(rbody, inputDetector.Movement().x, speed, acceleration, decceleration, velPower);
        }
        if(inputDetector.Movement().y > 0 && IsGrounded()) {
            VerticalMovement.Jump(rbody, jumpForce);
        }
        if(inputDetector.Movement().y < 0 && !IsGrounded()) {
            VerticalMovement.Fall(rbody, fallForce, minFallSpeed);
        }
    }
}
