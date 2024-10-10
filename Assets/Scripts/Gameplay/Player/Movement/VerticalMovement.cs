using UnityEngine;

namespace Movement
{
    public static class VerticalMovement
    {
        /*
        public static void Jump(CharacterController controller, Vector3 playerVelocity, float jumpHeight, float gravityValue, bool groundedPlayer) {
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }*/

        public static void Jump(Rigidbody2D Rbody, float JumpForce) {
            Rbody.AddForce(Rbody.transform.up * JumpForce, ForceMode2D.Impulse);
        }
        public static void Fall(Rigidbody2D Rbody, float FallForce, float MinFallSpeed) {
            Vector2 fallForceVector = Vector2.up * Physics2D.gravity.y * FallForce * Time.fixedDeltaTime;
            Rbody.linearVelocity += fallForceVector;

            Rbody.linearVelocity = new Vector2(Rbody.linearVelocity.x, Mathf.Min(Rbody.linearVelocity.y, MinFallSpeed));
        }
        public static void HandleVerticalMovement(Rigidbody2D Rbody, bool direction, bool Grounded, float JumpForce, float FallForce, float MinFallSpeed)
        {
            if (Grounded) {
                Rbody.AddForce(Rbody.transform.up * JumpForce, ForceMode2D.Impulse);
            }

            else if (!Grounded && Rbody.linearVelocity.y < 0) {
                Vector2 fallForceVector = Vector2.up * Physics2D.gravity.y * FallForce * Time.fixedDeltaTime;
                Rbody.linearVelocity += fallForceVector;

                Rbody.linearVelocity = new Vector2(Rbody.linearVelocity.x, Mathf.Min(Rbody.linearVelocity.y, MinFallSpeed));
            }
        }
        //Split this into jump and fall
    }

}
