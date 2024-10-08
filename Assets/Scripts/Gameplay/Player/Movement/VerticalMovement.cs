using UnityEngine;

namespace Movement
{
    public static class VerticalMovement
    {
        public static void Jump(CharacterController controller, Vector3 playerVelocity, float jumpHeight, float gravityValue, bool groundedPlayer) {
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }

}
