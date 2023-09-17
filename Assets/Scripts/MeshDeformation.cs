using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformation : MonoBehaviour
{
    [Range(1.5f, 5f)]
    public float radius = 2f;

    [Range(1.5f, 5f)]
    public float deformationStrength = 2f;

    public Mesh mesh;

    private Vector3[] vertices, modifiedVertices;

    public HapticPlugin hapticDevice;

    public LayerMask layer;

    private Vector3 gizmoCollision = Vector3.zero;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    void RecalculateMesh()
    {
        mesh.vertices = modifiedVertices;
        hit.transform.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateNormals();
        mesh = null;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.up * -1.0f);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            gizmoCollision = hit.point;
            mesh = hit.transform.gameObject.GetComponent<MeshFilter>().mesh;
            Debug.Log("Tip is beaming" + mesh.name);
            vertices = mesh.vertices;
            modifiedVertices = mesh.vertices;
            for (int i = 0; i < modifiedVertices.Length; i++)
            {
                Vector3 distance = modifiedVertices[i] - hit.point;

                float smoothingFactor = 2f;
                float force = deformationStrength / (1f + hit.point.sqrMagnitude);

                if (distance.sqrMagnitude < radius)
                {
                    if (hapticDevice.Buttons[0] == 1)
                    {
                        modifiedVertices[i] = modifiedVertices[i] + (Vector3.up * force) / smoothingFactor;
                    }
                    if (hapticDevice.Buttons[1] == 1)
                    {
                        modifiedVertices[i] = modifiedVertices[i] + (Vector3.down * force) / smoothingFactor;
                    }
                }
            }
            hapticDevice.setupShapes();
        }
        if (mesh != null)
        {
            RecalculateMesh();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gizmoCollision, 0.02f);
    }
}
