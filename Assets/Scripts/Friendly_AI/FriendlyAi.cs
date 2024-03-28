using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAi : MonoBehaviour
{
    private GameObject _player;
    private NavMeshAgent _agent;
    private float _xOffset, _zOffset, _timeUntilPosChange;
    [SerializeField] private float _changePositionTimer;

    [SerializeField] private LayerMask _groundLayer, _playerLayer;

    [SerializeField] float _sightRange, _followRange;
    private bool _playerFollow, _inRange;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player");
        _changePositionTimer = Random.Range(4, 9);
    }

    private void Update()
    {
        _timeUntilPosChange += Time.deltaTime;

        _playerFollow = Physics.CheckSphere(transform.position, _sightRange, _playerLayer);
        _inRange = Physics.CheckSphere(transform.position, _followRange, _playerLayer);
        _agent.SetDestination(_player.transform.position);

        if (_playerFollow && _inRange)
            FollowPlayer();

    }

    private void FollowPlayer()
    {
        if (_timeUntilPosChange > _changePositionTimer) 
        {
            _xOffset = Random.Range(-5.0f, 5.0f);
            _zOffset = Random.Range(1.5f, 5f);
            _timeUntilPosChange = 0;
        }
        _agent.destination = new Vector3(_player.transform.position.x +_xOffset, _player.transform.position.y, _player.transform.position.z +_zOffset);
 
    }
}
