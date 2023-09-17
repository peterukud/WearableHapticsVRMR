using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformationCollisions : MonoBehaviour
{
    [Range(1.5f, 5f)]
    public float radius = 2f;

    [Range(1.5f, 5f)]
    public float deformationStrength = 2f;

    private Mesh mesh;

    public Vector3[] vertices, modifiedVertices;

    public HapticPlugin hapticDevice;

    public string stylusTag;

    // Start is called before the first frame update
    void Start()
    {
        mesh = this.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        modifiedVertices = mesh.vertices;
    }

    void RecalculateMesh()
    {
        mesh.vertices = modifiedVertices;
        this.GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter: " + collision.gameObject.tag);
    }

    void OnCollisionStay(Collision collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        //}


        if (collision.gameObject.tag == stylusTag)
        {
            Debug.Log("SculptingCollision ongoing");
            for (int i = 0; i < modifiedVertices.Length; i++)
            {
                Vector3 distance = modifiedVertices[i] - collision.GetContact(0).point;

                float smoothingFactor = 2f;
                float force = deformationStrength / (1f + collision.GetContact(0).point.sqrMagnitude);

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
        }
        RecalculateMesh();
    }
}
