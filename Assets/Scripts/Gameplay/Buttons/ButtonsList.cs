using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Button;
using UnityEngine;
using UnityEngine.Events;

public class ButtonList : MonoBehaviour
{
    private List<KeyCode> buttons = new List<KeyCode>();
    public List<KeyCode> Buttons { get => buttons; private set => buttons = value; }
    public UnityEvent randomiseKeysEvent;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode abilityKey;

    private KeyCode oldLeftKey;
    private KeyCode oldRightKey;
    private KeyCode oldUpKey;
    private KeyCode oldDownKey;
    private KeyCode oldAbilityKey;

    #region Getters
    public KeyCode LeftKey { get => leftKey; private set => leftKey = value; }
    public KeyCode RightKey { get => rightKey; private set => rightKey = value; }
    public KeyCode UpKey { get => upKey; private set => upKey = value; }
    public KeyCode DownKey { get => downKey; private set => downKey = value; }
    public KeyCode AbilityKey { get => abilityKey; private set => abilityKey = value; }
    #endregion

    private void Start() {
        AddButtons();
        DefaultButtons();

        Debug.Log("Up Key assigned to: " + UpKey);
        Debug.Log("Left Key assigned to: " + LeftKey);
        Debug.Log("Down Key assigned to: " + DownKey);
        Debug.Log("Right Key assigned to: " + RightKey);
        Debug.Log("Ability Key assigned to: " + AbilityKey);
    }

    public void ReRandomise() {
        randomiseKeysEvent.Invoke();
        SavePrevKeys();
        ButtonRandomiser.RandomiseKeys(Buttons);

        Buttons.Remove(oldUpKey);
        Buttons.Remove(oldLeftKey);
        Buttons.Remove(oldDownKey);
        Buttons.Remove(oldRightKey);
        Buttons.Remove(oldAbilityKey);
        UpKey = buttons[0];
        LeftKey = buttons[1];
        DownKey = buttons[2];
        RightKey = buttons[3];
        AbilityKey = buttons[4];
        Buttons.InsertRange(5, new KeyCode[] { oldUpKey, oldLeftKey, oldDownKey, oldRightKey, oldAbilityKey });
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

    private void SavePrevKeys() {
        oldUpKey = UpKey;
        oldLeftKey = LeftKey;
        oldDownKey = DownKey;
        oldRightKey = RightKey;
        oldAbilityKey = AbilityKey;
    }

    public void DefaultButtons() {
        KeyCode[] keyCodes = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Q };

        SetKeys(keyCodes);

        UpKey = KeyCode.W;
        LeftKey = KeyCode.A;
        DownKey = KeyCode.S;
        RightKey = KeyCode.D;
        AbilityKey = KeyCode.Q;

        Debug.Log("Keys set to default WASD controls in the specified order.");
    }

    private void SetKeys(KeyCode[] keyCodes) {
        foreach (var keyCode in keyCodes) {
            buttons.Remove(keyCode);
        }
        buttons.InsertRange(0, keyCodes);
    }
}
