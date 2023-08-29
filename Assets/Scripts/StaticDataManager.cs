using System;
using System.IO;
using UnityEngine;

public class StaticDataManager : MonoBehaviour
{
    public static StaticDataManager Instance;

    public string PlayerName { get; set; }

    public int HighScore { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public HighScoreData LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var highScore = JsonUtility.FromJson<HighScoreData>(json);
            this.HighScore = highScore.Score;

            return highScore;
        }

        return null;
    }

    public void SaveHighScore(int score)
    {
        string path = Application.persistentDataPath + "/highscore.json";
        HighScoreData data = new HighScoreData { Score = score, PlayerName = this.PlayerName };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
        this.HighScore = score;
    }

    [Serializable]
    public class HighScoreData
    {
        public int Score;
        public string PlayerName;
    }
}
