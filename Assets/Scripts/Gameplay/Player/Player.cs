using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    public CharacterController Controller { get => controller; set => controller = value; }
    public float PlayerSpeed { get => playerSpeed; private set => playerSpeed = value; }
    public float JumpHeight { get => jumpHeight; private set => jumpHeight = value; }
    public float GravityValue { get => gravityValue; private set => gravityValue = value; }

    private void Start() {
        controller = gameObject.AddComponent<CharacterController>();
    }
    
}
