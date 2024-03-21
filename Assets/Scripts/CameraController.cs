using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _sensitivity;
    private float _rotateHorizontal;
    private float _rotateVertical;

    private void Awake()
    {
        if (!_player)
            _player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        _rotateHorizontal = Input.GetAxis("Mouse X");
        _rotateVertical = Input.GetAxis("Mouse Y");

        transform.RotateAround(_player.transform.position, -Vector3.up, _rotateHorizontal * _sensitivity);
        //transform.RotateAround(Vector3.zero, transform.right, _rotateVertical * _sensitivity);
        //transform.rotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.x, -90, 90), transform.rotation.y, transform.rotation.z);
    }
}
