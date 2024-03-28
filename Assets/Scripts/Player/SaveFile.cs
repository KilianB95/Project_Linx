using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
    private PlayerData _playerData = new();
    public PlayerData PlayerData { get { return _playerData; } }
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

    public void GetFromSaveFile()
    {
        if (File.Exists(_saveFilePath))
        {
            string loadedPlayerData = File.ReadAllText(_saveFilePath);

            _playerData = JsonUtility.FromJson<PlayerData>(loadedPlayerData);
        }
        else
        {
            Debug.Log("ERROR: No save file!");
        }
    }
}