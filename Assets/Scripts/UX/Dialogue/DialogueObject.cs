using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    private string introMessage;

    public void SetDialogue(string[] newDialogue)
    {
        dialogue = newDialogue;
    }

    public DialogueObject(string introMessage)
    {
        this.introMessage = introMessage;
    }

    public string[] Dialogue => this.dialogue;
}
