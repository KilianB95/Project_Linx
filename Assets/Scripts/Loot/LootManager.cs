using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    private int _coinsToDrop;
    private float _yRotation;
    [SerializeField] private ObjectPooling _coinPool;

      
    private void OnDisable()
    {
        _coinsToDrop = Random.Range(3, 6);
        
        for (int i = 0; i < _coinsToDrop; i++)
        {
            GameObject coin = _coinPool.GetObstacle(false);
            coin.transform.position = transform.position;
            coin.transform.Rotate(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + (360 / _coinsToDrop) * i, transform.rotation.eulerAngles.z);
            Debug.Log(coin.transform.eulerAngles.y);
            coin.SetActive(true);
        }
    }
}