using UnityEngine;

namespace Movement
{
    public static class HorizontalMovement 
    {
        /*
        public static void Walk(CharacterController controller, float playerSpeed) {
            Vector3 move = new Vector2(Input.GetAxis("Horizontal"), 0);
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
        
        public static void Walk(Rigidbody2D rbody, float direction, float speed)
        {
            rbody.linearVelocity = new Vector2(direction * speed, rbody.linearVelocity.y);
        }
        */

        public static void Run(Rigidbody2D rbody, float direction, float speed, float acceleration, float decceleration, float velPower)
        {
            float targetSpeed = direction * speed;
            float speedDif = targetSpeed - rbody.linearVelocity.x;
            float accelRate = (Mathf.Abs(targetSpeed) > 9.91f) ? acceleration : decceleration;
            float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
            rbody.AddForce(movement * Vector2.right);
        }
    }
}
