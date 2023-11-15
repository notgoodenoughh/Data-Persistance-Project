using System;
using System.IO;
using UnityEngine;

public class PlayerPersistance : MonoBehaviour
{
    public const string FILE_NAME = "/PlayerData.json";
    public static PlayerPersistance Instance;

    public string playerName;
    public int highscore;

    [Serializable]
    public class PlayerData
    {
        public string name;
        public int highscore;

        public PlayerData(string name, int highscore)
        {
            this.name = name;
            this.highscore = highscore;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(this);

        PlayerData data = LoadData();
        if (data != null)
        {
            playerName = data.name;
            highscore = data.highscore;
        }
    }

    public void SaveData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + FILE_NAME;

        File.WriteAllText(path, json);
    }

    public PlayerData LoadData()
    {
        string path = Application.persistentDataPath + FILE_NAME;
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }

        return null;
    }
}