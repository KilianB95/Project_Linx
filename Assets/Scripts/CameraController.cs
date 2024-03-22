using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _sensitivity;

    private void Awake()
    {
        if (!_player)
            _player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.RotateAround(_player.transform.position, _player.transform.forward, 0);

        //transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
    }

    public float GetSensitivity()
    {
        return _sensitivity;
    }
}
