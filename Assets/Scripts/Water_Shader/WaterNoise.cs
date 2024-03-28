using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNoise : MonoBehaviour
{
    [SerializeField] private float _power = 3, _scale = 1, _timeScale = 1;
    
    private float _xOffset, _yOffset;
    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        MakeNoise();
    }

    private void Update()
    {
        MakeNoise();
        _xOffset += Time.deltaTime * _timeScale;
        _yOffset += Time.deltaTime * _timeScale;
    }

    private void MakeNoise()
    {
        Vector3[] verticies = _meshFilter.mesh.vertices;

        for (int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z * _power);
        }

        _meshFilter.mesh.vertices = verticies;
        _meshFilter.mesh.RecalculateNormals();
    }

    private float CalculateHeight(float x, float y)
    {
        float xCordinate = x * _scale + _xOffset;
        float ycordinate = y * _scale + _yOffset;

        return Mathf.PerlinNoise(xCordinate, ycordinate);
    }
}
