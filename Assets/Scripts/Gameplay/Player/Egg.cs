using UnityEngine;
using Movement;

public class Egg : MonoBehaviour
{
    private InputDetector inputDetector;
    [SerializeField] private float speed = 15.0f;  // Default speed
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float friction = 0.9f;
    [SerializeField] private float wobbleIntensity = 2.0f;
    [SerializeField] private float wobbleFrequency = 3.0f;
    private bool canMove = true;
    private Rigidbody2D rbody;

    public bool CanMove { get => canMove; set => canMove = value; }

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        inputDetector = FindAnyObjectByType<InputDetector>();
    }

    private void FixedUpdate() {
        Vector2 movementInput = inputDetector.Movement();

        if (movementInput != Vector2.zero && canMove) {
            RollInDirection(movementInput);
        } else {
            ApplyFriction();
        }

        ApplyWobbleEffect();
    }

    private void RollInDirection(Vector2 direction) {
        Vector2 targetVelocity = direction.normalized * speed;
        Vector2 velocityDiff = targetVelocity - rbody.linearVelocity;
        
        Vector2 force = velocityDiff * acceleration * Time.fixedDeltaTime;
        rbody.AddForce(force, ForceMode2D.Force);
    }

    private void ApplyFriction() {
        rbody.linearVelocity *= friction;
    }

    private void ApplyWobbleEffect() {
        float wobble = Mathf.Sin(Time.time * wobbleFrequency) * wobbleIntensity;
        rbody.rotation += wobble * Time.fixedDeltaTime;
    }
}
