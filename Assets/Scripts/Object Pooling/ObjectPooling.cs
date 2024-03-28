using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject _objectPool;
    [SerializeField] private Queue<GameObject> _objectPooler = new Queue<GameObject>();
    [SerializeField] private int _poolStartSize;
    public int PoolStartSize { get { return _poolStartSize; } }

    //Wanneer de game start maakt hij de hoeveelheid objecten aan door middel van _poolStartSize.
    void Start()
    {
        for (int i = 0; i < _poolStartSize; i++)
        {
            GameObject obstacle = Instantiate(_objectPool);
            _objectPooler.Enqueue(obstacle);
            obstacle.SetActive(false);
        }
    }

    // Vanaf hier maakt die de objecten true en spawnen ze in.
    public GameObject GetObstacle(bool setActiveImmediately = true)
    {
        if (_objectPooler.Count > 0)
        {
            GameObject obstacle = _objectPooler.Dequeue();
            obstacle.SetActive(setActiveImmediately);
            return obstacle;
        }
        else
        {
            GameObject obstacle = Instantiate(_objectPool);
            _objectPooler.Enqueue(obstacle);
            obstacle.SetActive(setActiveImmediately);
            return obstacle;
        }
    }

    //Zet object terug in de queue
    public void ReturnObstacle(GameObject collison)
    {
        _objectPooler.Enqueue(collison);
        collison.SetActive(false);
    }
}