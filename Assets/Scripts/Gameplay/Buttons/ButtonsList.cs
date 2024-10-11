using System.Collections;
using System.Collections.Generic;
using Button;
using UnityEngine;

public class ButtonList : MonoBehaviour
{
    private List<KeyCode> buttons = new List<KeyCode>();
    public List<KeyCode> Buttons { get => buttons; private set => buttons = value; }

    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode abilityKey;

    public KeyCode LeftKey { get => leftKey; private set => leftKey = value; }
    public KeyCode RightKey { get => rightKey; private set => rightKey = value; }
    public KeyCode UpKey { get => upKey; private set => upKey = value; }
    public KeyCode DownKey { get => downKey; private set => downKey = value; }
    public KeyCode AbilityKey { get => abilityKey; private set => abilityKey = value; }

    private void Start() {
        AddButtons();
        ButtonRandomiser.RandomiseKeys(Buttons);

        UpKey = buttons[0];
        LeftKey = buttons[1];
        DownKey = buttons[2];
        RightKey = buttons[3];
        AbilityKey = buttons[4];

        Debug.Log("Up Key assigned to: " + UpKey);
        Debug.Log("Left Key assigned to: " + LeftKey);
        Debug.Log("Down Key assigned to: " + DownKey);
        Debug.Log("Right Key assigned to: " + RightKey);
        Debug.Log("Ability Key assigned to: " + AbilityKey);
    }


    private void AddButtons() { 
        TextAsset buttonsListTextAsset = Resources.Load<TextAsset>("Valid_Buttons"); // Load the text file
        string ButtonList = buttonsListTextAsset.text;

        for (int i = 0; i < ButtonList.Length; i++) {
            try {
                KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), ButtonList[i].ToString());
                Buttons.Add(keyCode);

                Debug.Log("Successfully added: " + ButtonList[i].ToString());
            }
            catch {
                Debug.LogError("Error loading " + ButtonList[i] + ". Is the button an invalid type?");
            }
        }
    }

    public void DefaultButtons() {
        LeftKey = KeyCode.A;
        RightKey = KeyCode.D;
        UpKey = KeyCode.W;
        DownKey = KeyCode.S;
        AbilityKey = KeyCode.Q;
    }
}
