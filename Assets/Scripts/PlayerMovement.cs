using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _playerController;
    private CameraController _cameraController;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Camera _mainCamera;
    private Vector3 _moveDirection; //Wordt automatisch gezet via InputManager in Edit > Project Settings > Input Manager. Staat standaard op W A S D

    private void Awake()
    {
        _playerController = GetComponent<CharacterController>();
        _mainCamera = Camera.main; //Werkt op de "MainCamera" tag
        _cameraController = _mainCamera.GetComponent<CameraController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        _moveDirection = Vector3.zero;
        _moveDirection += _moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime * transform.forward; // W en S
        _moveDirection += _moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime * transform.right; // A en D

        _playerController.Move(_moveDirection);

        
    }

    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * _cameraController.GetSensitivity(), 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
