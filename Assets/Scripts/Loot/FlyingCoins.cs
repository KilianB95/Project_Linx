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
    }

    private void OnEnable()
    {
        _flyDirection += transform.up * _upModifier;
        _flyDirection += transform.forward * _forwardModifier;
        _rb.AddForce(_flyDirection);
    }
}
