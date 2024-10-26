using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.TryGetComponent(out Rigidbody2D rb)) {
            rb.AddForce(rb.transform.up*bounceForce, ForceMode2D.Impulse);
        }
    }
}
