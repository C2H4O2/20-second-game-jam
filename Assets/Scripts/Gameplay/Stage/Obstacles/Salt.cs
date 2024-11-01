using UnityEngine;
using UnityEngine.Events;

public class Salt : MonoBehaviour
{
    public UnityEvent SaltGrabEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EggWhites")
        {
            Debug.Log("The " + other.gameObject.name + " collected the salt");
            SaltGrabEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
