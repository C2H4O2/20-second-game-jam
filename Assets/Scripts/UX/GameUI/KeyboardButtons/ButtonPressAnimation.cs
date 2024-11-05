using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressAnimation : MonoBehaviour
{
    private ButtonList buttonList;
    [SerializeField] private int ID;
    [SerializeField] private Sprite ButtonPressedImage;
    [SerializeField] private Sprite ButtonReleasedImage;
    private Image keyImage;
    private TMP_Text keyText;
    private Vector2 defaultPos;
    private Vector2 pressedPos;
    private Color defaultColor;
    private Color redColor = Color.red;

    private void Awake() {
        buttonList = FindAnyObjectByType<ButtonList>();
        keyImage = GetComponent<Image>();
        keyText = GetComponentInChildren<TMP_Text>();
        defaultColor = keyImage.color;
    }

    private void Start() {
        defaultPos = keyText.rectTransform.anchoredPosition;
        pressedPos = keyText.rectTransform.anchoredPosition + new Vector2(0, -10);
    }

    private void Update() {
        ChangeKeyText();
        
        // Check if the main key (Buttons[ID]) is pressed
        if (Input.GetKey(buttonList.Buttons[ID])) {
            keyImage.sprite = ButtonPressedImage;
            keyText.rectTransform.anchoredPosition = pressedPos;
        } else {
            keyImage.sprite = ButtonReleasedImage;
            keyText.rectTransform.anchoredPosition = defaultPos;
        }

        if (Input.GetKey(buttonList.Buttons[ID + 5]) ) {
            keyImage.color = redColor; 
        } else {
            keyImage.color = defaultColor;
        }
    }

    private void ChangeKeyText() {
        keyText.text = buttonList.Buttons[ID].ToString();
    }
    
    private bool IsKeyInNewRandomKeys(KeyCode key) {
        for (int i = 0; i < 5; i++) {
            if (buttonList.Buttons[i] == key) {
                return true;
            }
        }
        return false;
    }
}
