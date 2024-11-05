using System.Linq;
using UnityEngine;

public class WhiskAnimation : MonoBehaviour
{
    [SerializeField] private AudioClip whiskSoundClip;
    [SerializeField] private RectTransform uiElement;
    [SerializeField] private RectTransform[] pathPoints;
    [SerializeField] private float duration = 3f;
    private Vector2 originalPosition;

    private void Start() {
        originalPosition = uiElement.position;
    }

    public void Scramble() {
        SoundFXManager.instance.PlaySoundFXClip(whiskSoundClip, transform, 1f);
        // Create a path from the specified points
        Vector3[] path = pathPoints.Select(point => point.position).ToArray();

        // Move along the spline path with LeanTween
        LeanTween.moveSpline(uiElement.gameObject, path, duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => {
                LeanTween.delayedCall(1f, () => uiElement.position = originalPosition);
            });
    }
}
