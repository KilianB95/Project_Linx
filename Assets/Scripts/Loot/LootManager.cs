using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    private int _coinsToDrop;
    [SerializeField] private ObjectPooling _coinPool;

      
    private void OnDisable()
    {
        _coinsToDrop = Random.Range(3, 6);
        
        for (int i = 0; i < _coinsToDrop; i++)
        {
            GameObject coin = _coinPool.GetObstacle();
            coin.transform.position = transform.position;
            coin.transform.Rotate(transform.rotation.eulerAngles.x, Random.Range(0, 360), transform.rotation.eulerAngles.z);
        }
    }
}