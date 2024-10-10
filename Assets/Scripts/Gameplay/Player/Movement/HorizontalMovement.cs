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
        */
        public static void Walk(Rigidbody2D rbody, bool direction, float speed)
        {
            int sign = direction ? 1:-1; 
            rbody.linearVelocity = new Vector2(sign * speed, rbody.linearVelocity.y);
        }
    }
}
