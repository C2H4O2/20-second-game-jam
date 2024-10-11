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
    
    private void Awake() {
        buttonList = FindAnyObjectByType<ButtonList>();
        keyImage = GetComponent<Image>();
        keyText = GetComponentInChildren<TMP_Text>();
    }

    private void Start() {
        defaultPos = keyText.rectTransform.anchoredPosition;
        pressedPos = keyText.rectTransform.anchoredPosition += new Vector2(0,-10);
    }

    private void Update() {
        ChangeKeyText();
        if(Input.GetKey(buttonList.Buttons[ID])) {
            keyImage.sprite = ButtonPressedImage;
            keyText.rectTransform.anchoredPosition =pressedPos;
        }
        else {
            keyImage.sprite = ButtonReleasedImage;
            keyText.rectTransform.anchoredPosition = defaultPos;
            
        }

    }

    private void ChangeKeyText() {
        keyText.text = buttonList.Buttons[ID].ToString();
    }
    
    
}
