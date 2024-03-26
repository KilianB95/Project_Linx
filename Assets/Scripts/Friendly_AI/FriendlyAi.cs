using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAi : MonoBehaviour
{
    private GameObject _player;
    private NavMeshAgent _agent;

    [SerializeField] private LayerMask _groundLayer, _playerLayer;

    [SerializeField] float _sightRange, _followRange;
    private bool _playerFollow, _inRange;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        _playerFollow = Physics.CheckSphere(transform.position, _sightRange, _playerLayer);
        _inRange = Physics.CheckSphere(transform.position, _followRange, _playerLayer);
        _agent.SetDestination(_player.transform.position);

        if(_playerFollow && !_inRange)
            FollowPlayer();

    }

    private void FollowPlayer()
    {
        _agent.SetDestination(_player.transform.position);
    }
}
