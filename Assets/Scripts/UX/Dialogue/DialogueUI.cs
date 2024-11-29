using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject dialogueObject;

    [SerializeField] private bool startOfDialogue;
    [SerializeField] private UnityEvent completedDialogueObject;


    public bool IsOpen { get; private set; }
    public DialogueObject DialogueObject { get => dialogueObject; set => dialogueObject = value; }

    private TypewriterEffect typeWriterEffect;

    private void Start()
    {

        typeWriterEffect = GetComponent<TypewriterEffect>();

        CloseDialogueBox();
        if(startOfDialogue)
            ShowDialogue();
    }


    public void ShowDialogue()
    {
        IsOpen = true;
        StartCoroutine(StepThroughDialogue(this.dialogueObject));

    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);
            textLabel.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1) break;
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typeWriterEffect.Run(dialogue, textLabel);

        while (typeWriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                typeWriterEffect.Stop();
            }
        }
        completedDialogueObject.Invoke();
        
    }

    public void CloseDialogueBox()
    {
        IsOpen = false;
        textLabel.text = string.Empty;
    }
}