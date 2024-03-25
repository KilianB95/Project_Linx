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
    private float _jumpTime;
    private bool _isJumping;
    private Vector3 _verticalDirection; //Jump movement
    private Vector3 _horizontalDirection; //WASD movement
    private Vector3 _moveDirection; //Gecombineerd

    private void Awake()
    {
        _playerController = GetComponent<CharacterController>();
        _mainCamera = Camera.main; //Werkt op de "MainCamera" tag
        _cameraController = _mainCamera.GetComponent<CameraController>();
        Cursor.lockState = CursorLockMode.Locked;
        _isJumping = false;
    } 

    private void Update()
    {
        Debug.Log(_playerController.isGrounded);

        _horizontalDirection = Vector3.zero;
        _horizontalDirection += _moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime * transform.forward; // W en S
        _horizontalDirection += _moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime * transform.right; // A en D

        transform.Rotate(0, Input.GetAxis("Mouse X") * _cameraController.GetSensitivity(), 0); //Draaien met de muis

        if (Input.GetButtonDown("Jump") && _playerController.isGrounded)
            _isJumping = true;

        if (_jumpTime > _jumpForce / 10) //Deelt _jumpForce door 10, daarna wordt je niet meer omhoog geduwd
            _isJumping = false;

        _jumpTime = _isJumping ? _jumpTime += Time.deltaTime : 0;
        _verticalDirection.y = _isJumping ? _jumpForce * Time.deltaTime : -_jumpForce * Time.deltaTime; //Wanneer _isJUmping 

        _moveDirection.Set(_horizontalDirection.x, _verticalDirection.y, _horizontalDirection.z);
        _playerController.Move(_moveDirection);
    }
}
