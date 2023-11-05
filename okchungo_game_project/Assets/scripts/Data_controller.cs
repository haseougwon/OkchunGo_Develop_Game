using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Data_controller : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }

    static Data_controller _instance;
    public static Data_controller Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "Data_controller";
                _instance = _container.AddComponent(typeof(Data_controller)) as Data_controller;
                DontDestroyOnLoad( _container );
            }
            return _instance;
        }
    }

    public string GameDataFileName = "okchungogame.Json";

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if (File.Exists(filePath))
        {
            Debug.Log("�ҷ����� ����");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            Debug.Log("���ο� ���� ����");

            _gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("���� �Ϸ�");
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
