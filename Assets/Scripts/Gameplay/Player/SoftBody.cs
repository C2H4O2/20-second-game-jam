using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    private const float splineoffset = 0.5f;
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField] private Transform[] points;
    [SerializeField] private float scaleFactor = 1.0f;

    [SerializeField] private List<SpringJoint2D> joints;

    private void Awake()
    {
        foreach(var point in points) {
            foreach (var springJoint2D in point.GetComponents<SpringJoint2D>())
            {
                joints.Add(springJoint2D);
            }
            
        }
        
        UpdateVertices();
    }

    private void Update()
    {
        UpdateVertices();
    }

    public void ScaleShape(float scaleAmount)
    {
        scaleFactor = scaleAmount;
        UpdateVertices();
    }

    private double StiffnessEquation(double x) {
        return Math.Sqrt(2) * Math.Pow(2,1/40*x);
    }

    private void UpdateVertices()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 vertex = points[i].localPosition * scaleFactor;
            Vector2 towardsCenter = (Vector2.zero - vertex).normalized;
            float colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;

            try
            {
                spriteShapeController.spline.SetPosition(i, vertex - towardsCenter * colliderRadius);
            }
            catch
            {
                Debug.Log("Spline points are too close to each other. Recalculating...");
                spriteShapeController.spline.SetPosition(i, vertex - towardsCenter * (colliderRadius + splineoffset));
            }

            Vector2 lt = spriteShapeController.spline.GetLeftTangent(i);
            Vector2 newRt = Vector2.Perpendicular(towardsCenter) * lt.magnitude;
            Vector2 newLt = Vector2.zero - newRt;

            spriteShapeController.spline.SetLeftTangent(i, newLt);
            spriteShapeController.spline.SetRightTangent(i, newRt);
        }
    }
}
