using UnityEngine;
using Movement;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private bool groundedPlayer;

    public CharacterController Controller { get => controller; private set => controller = value; }
    public float PlayerSpeed { get => playerSpeed; private set => playerSpeed = value; }
    public float JumpHeight { get => jumpHeight; private set => jumpHeight = value; }
    public float GravityValue { get => gravityValue; private set => gravityValue = value; }

    private void Start() {
        Controller = gameObject.AddComponent<CharacterController>();
    }

    private void Update() {
        HorizontalMovement.Walk(Controller, PlayerSpeed);
        VerticalMovement.Jump(Controller, playerVelocity, jumpHeight, gravityValue, groundedPlayer);
    }
}
