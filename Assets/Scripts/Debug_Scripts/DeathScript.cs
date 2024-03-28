using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private float _timeToKill;
    [SerializeField] private GameObject _victim;
    private float _timeUntilDeath;

    private void Update()
    {
        _timeUntilDeath += Time.deltaTime;
        _victim.SetActive(_timeUntilDeath < _timeToKill);
    }
}
