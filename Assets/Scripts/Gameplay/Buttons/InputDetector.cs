using Button;
using UnityEngine;


public class InputDetector : MonoBehaviour
{
    [SerializeField] ButtonList ButtonList;

    private void Awake() {
        ButtonList buttonList = FindAnyObjectByType<ButtonList>();
    }


    //Horizontal
    public Vector2 Movement() {
        Vector2 Movement = Vector2.zero;
        if(Input.GetKey(ButtonList.LeftKey)) {
            Movement += Vector2.left;
        }
        if(Input.GetKey(ButtonList.RightKey)) {
            Movement += Vector2.right;
        }
        if(Input.GetKey(ButtonList.UpKey)) {
            Movement += Vector2.up;
        }
        if(Input.GetKey(ButtonList.DownKey)) {
            Movement += Vector2.down;
        }
        return Movement;
    }

    //add ability if time
}

