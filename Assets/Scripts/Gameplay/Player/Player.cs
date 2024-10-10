using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallForce;
    [SerializeField] private float minFallSpeed;
    [SerializeField] private ButtonList buttonList;
    
    private bool facingRight;


    private Rigidbody2D rbody;
    private Vector2 moveInput;

    public bool FacingRight { get => facingRight; }
    public Rigidbody2D Rbody { get => rbody; }

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        buttonList = FindAnyObjectByType<ButtonList>();
    }
    private void Update() {

    }

    private bool IsGrounded() {
        return GetComponent<Rigidbody2D>().linearVelocity.y == 0;
    }
    
    private void FixedUpdate() {
        /*
        if() //able to walk
        HorizontalMovement.Walk(Rbody, true, speed); //Handle the movement direction when doing button
        if() //able to jump

        if() //able to fall
        VerticalMovement.HandleVerticalMovement(rbody, IsGrounded(), jumpForce, fallForce, minFallSpeed);
        */
    }
}
