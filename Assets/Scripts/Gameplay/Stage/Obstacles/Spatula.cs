using Unity.Collections;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    private Egg egg;
    private Rigidbody2D rb;
    [SerializeField] private float followSpeed = 2f; // Adjust for desired follow speed
    [SerializeField] private float followSmoothness = 0.05f; // Smoothing for more natural following

    private void Awake()
    {
        egg = FindAnyObjectByType<Egg>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("The Spatula hit " + other.gameObject.name);
        }
    }

    private void Update()
    {
        // Gradually move towards the player (Egg) position using a smoothed velocity
        Vector2 directionToEgg = (egg.transform.position - transform.position).normalized;
        
        // Calculate the new velocity towards the player with smoothing applied
        Vector2 targetVelocity = directionToEgg * followSpeed;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, followSmoothness);
    }
}
