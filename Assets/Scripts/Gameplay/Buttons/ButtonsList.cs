using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


public class ButtonList : MonoBehaviour
{
    Dictionary<int, KeyCode> buttons = new Dictionary<int, KeyCode>();

    private void Start() {
        AddButtons();
        
    }

    private void AddButtons() { //Read list of valid buttons from file
        TextAsset buttonsListTextAsset = Resources.Load<TextAsset>("Valid_Buttons");
        string ButtonList = buttonsListTextAsset.text;

        for (int i = 0; i < ButtonList.Length; i++) {
            try {
                buttons.Add(i, (KeyCode)System.Enum.Parse(typeof(KeyCode), ButtonList[i].ToString()));
                Debug.Log("Successfully added" + ButtonList[i].ToString());
            }
            catch {
                Debug.LogError("Error loading " + ButtonList[i] + "Is Button invalid type?");
            }
        }
    }

}


