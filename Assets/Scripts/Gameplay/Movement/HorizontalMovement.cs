using UnityEngine;

namespace Movement
{
    public class HorizontalMovement : MonoBehaviour
    {
        [SerializeField] private Player player;
        private void Update() {
            Vector3 move = new Vector2(Input.GetAxis("Horizontal"), 0);
            player.Controller.Move(move * Time.deltaTime * player.PlayerSpeed);
        }
    }
}

