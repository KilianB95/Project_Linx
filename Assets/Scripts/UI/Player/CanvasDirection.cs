using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class CanvasDirection : MonoBehaviour
{
    private RectTransform _transform;
    private Camera _camera;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _camera = Camera.main;
    }

    void Update()
    {
        _transform.LookAt(transform.position - (_camera.transform.position - transform.position));
    }
}
