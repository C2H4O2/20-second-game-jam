using System.Linq;
using UnityEngine;

public class WhiskAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform uiElement;
    [SerializeField] private RectTransform[] pathPoints;
    [SerializeField] private float duration = 3f;
    private Vector2 originalPosition;

    private void Start() {
        // Store the original position of the UI element before the animation
        originalPosition = uiElement.position;
    }

    public void Scramble() {
        // Create a path from the specified points
        Vector3[] path = pathPoints.Select(point => point.position).ToArray();

        // Move along the spline path with LeanTween
        LeanTween.moveSpline(uiElement.gameObject, path, duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => {
                // Wait 1 second before snapping back to the original position
                LeanTween.delayedCall(1f, () => uiElement.position = originalPosition);
            });
    }
}
