using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _playerController;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Camera _mainCamera;
    private Vector3 _moveDirection; //Wordt automatisch gezet via InputManager in Edit > Project Settings > Input Manager

    private void Awake()
    {
        _playerController = this.gameObject.GetComponent<CharacterController>();
        _mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        //_moveDirection.Set(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        _moveDirection = Vector3.zero;
        _moveDirection += _moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime * transform.forward;
        _moveDirection += _moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime * transform.right;

        _playerController.Move(_moveDirection);
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _mainCamera.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
