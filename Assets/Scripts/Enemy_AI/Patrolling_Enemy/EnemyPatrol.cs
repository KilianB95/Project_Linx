using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    private GameObject _player;

    private NavMeshAgent _agent;

    [SerializeField] private LayerMask _groundLayer, _playerLayer;

    private Vector3 _destinationPoint;
    private bool _walkingPoint;
    [SerializeField] private float _range;
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (!_walkingPoint) SearchDestination();
        if (_walkingPoint) _agent.SetDestination(_destinationPoint);
        if(Vector3.Distance(transform.position, _destinationPoint) < 10) _walkingPoint = false;
    }

    private void SearchDestination()
    {
        float z = Random.Range(-_range, _range);
        float x = Random.Range(-_range, _range);

        _destinationPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(_destinationPoint, Vector3.down, _groundLayer))
            _walkingPoint = true;
    }
}
