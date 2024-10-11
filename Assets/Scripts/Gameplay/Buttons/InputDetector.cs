using Button;
using UnityEngine;


public class InputDetector : MonoBehaviour
{
    [SerializeField] ButtonList buttonList;

    private void Awake() {
        buttonList = FindAnyObjectByType<ButtonList>();
    }

    
    //Horizontal
    public Vector2 Movement() {
        Vector2 Movement = Vector2.zero;
        if(Input.GetKey(buttonList.UpKey)) {
            Movement += Vector2.up;
        }
        if(Input.GetKey(buttonList.DownKey)) {
            Movement += Vector2.down;
        }
        if(Input.GetKey(buttonList.LeftKey)) {
            Movement += Vector2.left;
        }
        if(Input.GetKey(buttonList.RightKey)) {
            Movement += Vector2.right;
        }
        return Movement;
    }

    //add ability if time
}

