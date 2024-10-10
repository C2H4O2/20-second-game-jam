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
        public static void Walk(Rigidbody2D rbody, float direction, float speed)
        {
            rbody.linearVelocity = new Vector2(direction * speed, rbody.linearVelocity.y);
        }
    }
}
