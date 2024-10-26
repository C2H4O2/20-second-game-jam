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
    [SerializeField] private float rayDistance;
    [SerializeField] private float coyoteTimeDuration = 0.2f; // Coyote time duration
    private float coyoteTimeCounter; // Timer for coyote time

    private bool facingRight;
    private Rigidbody2D rbody;

    public bool FacingRight { get => facingRight; }
    public Rigidbody2D Rbody { get => rbody; }

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        inputDetector = FindAnyObjectByType<InputDetector>();
    }

    // Checks if player is grounded
    private bool IsGrounded() {
        return rbody.linearVelocity.y == 0 && Physics2D.Raycast(transform.position, Vector2.down, rayDistance);
    }

    private void FixedUpdate() {
        // Update coyote time counter if not grounded
        if (IsGrounded()) {
            coyoteTimeCounter = coyoteTimeDuration; // Reset counter when grounded
        } else {
            coyoteTimeCounter -= Time.fixedDeltaTime; // Countdown timer if in the air
        }

        // Horizontal movement
        if (inputDetector.Movement().x != 0) {
            HorizontalMovement.Run(rbody, inputDetector.Movement().x, speed, acceleration, decceleration, velPower);
        }

        // Jump if the player presses up and either is grounded or has coyote time left
        if (inputDetector.Movement().y > 0 && coyoteTimeCounter > 0) {
            VerticalMovement.Jump(rbody, jumpForce);
            coyoteTimeCounter = 0; // Reset counter to prevent double jumps
        }

        // Fall faster if moving down and not grounded
        if (inputDetector.Movement().y < 0 && !IsGrounded()) {
            VerticalMovement.Fall(rbody, fallForce, minFallSpeed);
        }
    }
}
