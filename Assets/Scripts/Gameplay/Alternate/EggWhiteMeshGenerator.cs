using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D), typeof(MeshFilter), typeof(MeshRenderer))]
public class EggWhiteMeshGenerator : MonoBehaviour
{
    private PolygonCollider2D polyCollider;
    private MeshFilter meshFilter;
    private Mesh originalMesh;
    private Vector2[] originalPoints;

    // Reference to a target collider for shape matching
    [SerializeField] private PolygonCollider2D targetCollider;

    private void Awake()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
        meshFilter = GetComponent<MeshFilter>();

        GenerateMesh();

        // Store the original collider shape and mesh
        originalPoints = polyCollider.points;
        originalMesh = meshFilter.mesh;
    }

    private void GenerateMesh()
    {
        // Convert collider points to mesh vertices
        Vector2[] points = polyCollider.points;
        Vector3[] vertices = new Vector3[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            vertices[i] = points[i];
        }

        // Create triangles for the mesh based on collider points
        Triangulator triangulator = new Triangulator(points);
        int[] triangles = triangulator.Triangulate();

        // Generate and assign the mesh
        Mesh mesh = new Mesh
        {
            vertices = vertices,
            triangles = triangles
        };
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        meshFilter.mesh = mesh;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Morph the egg shape to match the target collider's shape
        if (targetCollider != null)
        {
            AdjustColliderAndMesh(targetCollider.points);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reset to the original shape when collision ends
        polyCollider.points = originalPoints;
        meshFilter.mesh = originalMesh;
    }

    private void AdjustColliderAndMesh(Vector2[] targetPoints)
    {
        // Modify the collider points based on the target shape
        Vector2[] modifiedPoints = new Vector2[targetPoints.Length];
        
        for (int i = 0; i < modifiedPoints.Length; i++)
        {
            modifiedPoints[i] = targetPoints[i];
        }

        // Update the collider and mesh with modified points
        polyCollider.points = modifiedPoints;
        UpdateMesh(modifiedPoints);
    }

    private void UpdateMesh(Vector2[] modifiedPoints)
    {
        Vector3[] vertices = new Vector3[modifiedPoints.Length];
        for (int i = 0; i < modifiedPoints.Length; i++)
        {
            vertices[i] = modifiedPoints[i];
        }

        Mesh modifiedMesh = new Mesh
        {
            vertices = vertices,
            triangles = meshFilter.mesh.triangles  // Keep original triangles
        };
        modifiedMesh.RecalculateNormals();
        modifiedMesh.RecalculateBounds();

        meshFilter.mesh = modifiedMesh;
    }
}
