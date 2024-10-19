using UnityEngine;

public class Endgoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        ReachEndgoal();
    }

    private void ReachEndgoal() {
        Debug.Log("Player has reached the end");
    }
}
