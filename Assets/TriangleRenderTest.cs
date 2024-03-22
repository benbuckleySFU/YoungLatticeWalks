using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class TriangleRenderTest : MonoBehaviour
{
    public Material baseMaterial;
    // Start is called before the first frame update
    void Start()
    {
        generateWedge();
        
    }

    void generateWedge()
    {
        UnityEngine.Debug.Log("Just making sure this method is running.");
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[3];

        vertices[0] = new Vector3(-10, -10, 0);
        vertices[1] = new Vector3(-10, 10, 0);
        vertices[2] = new Vector3(10, -10, 0);

        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };
        GetComponent<MeshRenderer>().sharedMaterial = baseMaterial;
        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();

    }
}
