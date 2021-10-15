using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string userName;
    public string currentName;
    public int bestScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int bestScore;

    }
    [System.Serializable]
    class CurrentData
    {
        public string currentName;
    }

    public void SaveBestScore(string name, int score)
    {
        SaveData data = new SaveData();
        data.bestScore = score;
        data.userName = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
            bestScore = data.bestScore;
        }
    }

    public void LoadCurrentName(string name)
    {
        CurrentData data = new CurrentData();
        data.currentName = name;
    }

}
