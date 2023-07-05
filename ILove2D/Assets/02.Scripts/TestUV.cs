using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class TestUV : MonoBehaviour
{
    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    private void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3];
        int[] triangles = new int[3];

        vertices[0] = new Vector3(0, 0);
        vertices[1] = new Vector3(0, 4);
        vertices[2] = new Vector3(4, 4);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.triangles = triangles;




        _meshFilter.mesh = mesh;
    }

}