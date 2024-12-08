using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlameLightFlicker : MonoBehaviour
{
    private Light2D flameLight;

    // Parameters for flickering
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 1.5f;
    [SerializeField] private float flickerSpeed = 0.1f;

    void Start()
    {
        flameLight = GetComponent<Light2D>();
    }

    void Update()
    {
        flameLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * flickerSpeed, 1));
    }
}
