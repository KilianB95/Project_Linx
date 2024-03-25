using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkin : MonoBehaviour
{
    [SerializeField] private GameObject[] _skinPrefabs;
    [SerializeField] private Transform _spawnPoint;

    void Start()
    {
        int selectedSkin = PlayerPrefs.GetInt("selectedSkin");
        GameObject prefab = _skinPrefabs[selectedSkin];
        GameObject clone = Instantiate(prefab, _spawnPoint.position, Quaternion.identity);
    }

}
