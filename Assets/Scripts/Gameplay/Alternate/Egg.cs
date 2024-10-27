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
    [SerializeField] private float torquePower = 3.0f;  // Torque power for spinning effect
    [SerializeField] private float maxSpinSpeed = 300.0f;  // Cap for maximum spin speed
    private Rigidbody2D rbody;

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        inputDetector = FindAnyObjectByType<InputDetector>();
    }

    private void FixedUpdate() {
        Vector2 movementInput = inputDetector.Movement();

        if (movementInput != Vector2.zero) {
            RollInDirection(movementInput);
            //ApplySpinEffect(movementInput);
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

    private void ApplySpinEffect(Vector2 direction) {
        // Calculate torque based on the movement direction
        float torque = direction.magnitude * torquePower; // Magnitude of direction vector influences torque
        
        // Determine the spin direction: positive for right/up, negative for left/down
        if (direction.x > 0) {
            rbody.AddTorque(-torque);  // Spin counter-clockwise when moving right
        } else if (direction.x < 0) {
            rbody.AddTorque(torque);  // Spin clockwise when moving left
        }

        // Limit the spin speed to the maxSpinSpeed
        if (Mathf.Abs(rbody.angularVelocity) > maxSpinSpeed) {
            rbody.angularVelocity = Mathf.Sign(rbody.angularVelocity) * maxSpinSpeed;
        }
    }

    private void ApplyFriction() {
        rbody.linearVelocity *= friction;
    }

    private void ApplyWobbleEffect() {
        float wobble = Mathf.Sin(Time.time * wobbleFrequency) * wobbleIntensity;
        rbody.rotation += wobble * Time.fixedDeltaTime;
    }
}
