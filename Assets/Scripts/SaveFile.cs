using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
    private PlayerData _playerData = new PlayerData();
    private string _saveFilePath;

    private void Awake()
    {
        _saveFilePath = Application.persistentDataPath + "/PlayerData.json";
    }

    public void SaveToFile()
    {
        string jsonData = JsonUtility.ToJson(_playerData);

        File.WriteAllText(_saveFilePath, jsonData);
    }

    public PlayerData GetPlayerData()
    {
        return _playerData;
    }
}