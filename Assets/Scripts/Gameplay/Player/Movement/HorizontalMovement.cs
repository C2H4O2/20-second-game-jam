using UnityEngine;

namespace Movement
{
    public static class HorizontalMovement 
    {
        public static void Walk(CharacterController controller, float playerSpeed) {
            Vector3 move = new Vector2(Input.GetAxis("Horizontal"), 0);
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
    }
}
