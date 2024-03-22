using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _sensitivity;
    private float _mouseY;
    private float _xRotation;

    private void Awake()
    {
        if (!_player)
            _player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.RotateAround(_player.transform.position, _player.transform.forward, 0);

        _mouseY = Input.GetAxis("Mouse Y") * _sensitivity;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -20, 40);

        transform.eulerAngles = new Vector3(_xRotation, transform.eulerAngles.y, 0.0f);
    }

    public float GetSensitivity()
    {
        return _sensitivity;
    }
}
