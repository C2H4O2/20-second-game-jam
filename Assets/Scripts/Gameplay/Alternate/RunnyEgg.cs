using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RunnyEgg : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float trailSegmentDistance = 0.1f; // Distance between segments
    [SerializeField] private float maxTrailLength = 5.0f; // Limit the trail length

    private Vector3 lastTrailPosition;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lastTrailPosition = transform.position;
    }

    private void Update() {
        float distance = Vector3.Distance(transform.position, lastTrailPosition);

        if (distance >= trailSegmentDistance) {
            AddTrailPoint(transform.position);
            lastTrailPosition = transform.position;
        }

        // Trim the trail if it exceeds max length
        TrimTrail();
    }

    private void AddTrailPoint(Vector3 position) {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
    }

    private void TrimTrail() {
        if (lineRenderer.positionCount > maxTrailLength / trailSegmentDistance) {
            lineRenderer.positionCount--;
            for (int i = 1; i < lineRenderer.positionCount; i++) {
                lineRenderer.SetPosition(i - 1, lineRenderer.GetPosition(i));
            }
        }
    }
}
