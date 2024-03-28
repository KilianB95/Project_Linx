using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    [SerializeField] private float _size = 1;
    [SerializeField] private int _gridSize = 16;

    private MeshFilter _filter;

    private void Awake()
    {
        _filter = GetComponent<MeshFilter>();
        _filter.mesh = GenerateMesh();
    }

    private Mesh GenerateMesh()
    {
        Mesh mesh = new();

        var verticies = new List<Vector3>(); //Slaat de x,y,z as op.
        var normals = new List<Vector3>();
        var uvs = new List<Vector3>(); //Slaat de x & z as op.

        //In deze loop gaat hij af van welk punt die wilt pakken om daarmee een grid te kunnen maken.
        for(int x = 0; x < _gridSize + 1; x++)
        {
            for (int y = 0; y < _gridSize + 1; y++)
            {
                verticies.Add(new Vector3(-_size * 0.5f + _size * (x / ((float)_gridSize)), 0 , -_size * 0.5f + _size * (y / ((float)_gridSize))));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / (float)_gridSize, y / (float)_gridSize));
            }
        }

        //Na de loop hierboven gaat hij hier Triangles maken door middel van de loop erboven waardoor het een triangle maakt.
        //Gebaseerd op de waarden van de waarden die hij krijgt vanuit de loop.
        var triangles = new List<int>();
        var verticiesCount = _gridSize + 1;

        for(int i = 0; i < verticiesCount * verticiesCount - verticiesCount; i++)
        {
            if((i + 1) % verticiesCount == 0)
                continue;
            
            triangles.AddRange(new List<int>()
            {
                i+1+verticiesCount, i+verticiesCount, i,
                i, i+1, i+verticiesCount+1
            });
        }

        mesh.SetVertices(verticies);
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvs);
        mesh.SetTriangles(triangles, 0);

            return mesh;
    }
}
