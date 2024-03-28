using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    private bool _canFire;
    private float _timeUntilNextShot;
    private RaycastHit _hitObject;
    private GameObject _bulletOrigin;

    private void Awake()
    {
        _bulletOrigin = GameObject.Find("BulletOrigin");
        _canFire = true;
    }

    private void Update()
    {
        if (_timeUntilNextShot >= _fireRate)
            _canFire = true;

        _timeUntilNextShot = (!_canFire) ? _timeUntilNextShot + Time.deltaTime : 0;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _canFire)
            Shoot();
    }

    private void Shoot()
    {
        _canFire = false;

        if (Physics.Raycast(_bulletOrigin.transform.position, _bulletOrigin.transform.forward, out _hitObject, Mathf.Infinity)) 
            return;
            //Voeg toe dat enemies damage nemen of dood gaan
    }
}