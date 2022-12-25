using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderLine : MonoBehaviour
{
    public static LeaderLine Instance;
    public int _topScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int TopScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.TopScore = _topScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/LeaderLine.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/LeaderLine.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            _topScore = data.TopScore;
        }
    }
}
