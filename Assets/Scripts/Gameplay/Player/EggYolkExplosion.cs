using UnityEngine;

public class EggYolkExplosion : MonoBehaviour
{
    [SerializeField] private SpriteRenderer eggSprite;
    [SerializeField] private ParticleSystem eggYolkSplatterParticleSystem;
    private bool exploded = false;

    public void Explode() {
        //hide yolk
        //trigger particle
        if (!exploded) {
            eggYolkSplatterParticleSystem.gameObject.transform.position = eggSprite.gameObject.transform.position;
            eggSprite.color = new Color(0, 0, 0, 0);
            eggYolkSplatterParticleSystem.Play();
            exploded=true;
        }
        
    }
}
