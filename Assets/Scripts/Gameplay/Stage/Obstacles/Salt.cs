using UnityEngine;
using UnityEngine.Events;

public class Salt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EggWhites")
        {
            Inventory inventory = other.GetComponentInParent<Inventory>();
            inventory.IncrementSalt();
            Debug.Log("The " + other.gameObject.name + " collected the salt");
            Destroy(gameObject);
        }
    }
}
