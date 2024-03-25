using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTestScript : MonoBehaviour
{
    private SaveFile _saveFile;

    private void Awake()
    {
        _saveFile = GameObject.FindGameObjectWithTag("Player").GetComponent<SaveFile>();
    }

    private void Update()
    {
        if (_saveFile.GetPlayerData()._playerGold < 50)
        {
            _saveFile.GetPlayerData()._playerGold += 1;
            Debug.Log(_saveFile.GetPlayerData()._playerGold);
        }
        else
        {
            _saveFile.SaveToFile();
        }
    }
}
