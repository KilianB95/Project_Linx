using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlyingCoins : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _flyDirection;
    [SerializeField] private float _upModifier, _forwardModifier;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _flyDirection += Vector3.up * _upModifier;
        _flyDirection += Vector3.forward * _forwardModifier;
    }

    private void OnEnable()
    {
        _rb.AddForce(_flyDirection);
    }
}
