using System.Collections;
using System.Collections.Generic;
using Button;
using UnityEngine;

public class ButtonList : MonoBehaviour
{
    List<KeyCode> buttons = new List<KeyCode>();
    public List<KeyCode> Buttons { get => buttons; private set => buttons = value; }
    

    private void Start() {
        AddButtons();
        ButtonRandomiser.RandomiseKeys(Buttons);
    }

    // Add buttons to the list from the text file
    private void AddButtons() { 
        TextAsset buttonsListTextAsset = Resources.Load<TextAsset>("Valid_Buttons"); // Load the text file
        string ButtonList = buttonsListTextAsset.text;

        for (int i = 0; i < ButtonList.Length; i++) {
            try {
                KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), ButtonList[i].ToString());
                Buttons.Add(keyCode);

                Debug.Log("Successfully added " + ButtonList[i].ToString());
            }
            catch {
                Debug.LogError("Error loading " + ButtonList[i] + ". Is the Button an invalid type?");
            }
        }
    }
}
