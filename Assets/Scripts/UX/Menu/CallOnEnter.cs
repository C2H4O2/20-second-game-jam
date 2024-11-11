using UnityEngine;
using UnityEngine.Events;

public class CallOnEnter : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            onExit.Invoke();
        }
    }
}
