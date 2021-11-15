using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class WholeManager : MonoBehaviour
{
    public static WholeManager Instance;
    public string PlayerName;
    public int BestScore=0;
    public string BestPlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int BestScore;
        public string BestPlayer;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.BestScore = BestScore;
        data.BestPlayer = BestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            BestScore = data.BestScore;
            BestPlayer = data.BestPlayer;
        }
    }
}

