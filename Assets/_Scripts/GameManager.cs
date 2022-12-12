using System.IO;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string PREF_SOUND = "sound";

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public string PlayerInitials { get; set; } = "AAA";
    public bool HasSound { get; private set; } = true;

    public ScoreData Highscore { get; private set; }

    private string _saveFilePath;
    private string _highscoreSavePath;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        HasSound = PlayerPrefs.GetInt(PREF_SOUND, 1) == 1;

        _saveFilePath = Application.dataPath + "/savefile.csv";
        if (!File.Exists(_saveFilePath))
        {
            File.Create(_saveFilePath);
        }

        _highscoreSavePath = Application.dataPath + "/highscore.json";
        LoadHighscore();
    }

    public void EnableSound(bool enable)
    {
        HasSound = enable;

        PlayerPrefs.SetInt(PREF_SOUND, enable ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SaveScore(int score)
    {
        using StreamWriter writer = File.AppendText(_saveFilePath);
        writer.WriteLine(string.Format("{0};{1}", PlayerInitials, score));

        if(Highscore == null || score > Highscore.ScoreValue)
        {
            SaveHighscore(score);
        }
    }

    private void SaveHighscore(int score)
    {
        Highscore = new ScoreData();
        Highscore.PlayerInitials = PlayerInitials;
        Highscore.ScoreValue = score;

        var json = JsonUtility.ToJson(Highscore);
        File.WriteAllText(_highscoreSavePath, json);
    }
    private void LoadHighscore()
    {
        if (File.Exists(_highscoreSavePath))
        {
            var json = File.ReadAllText(_highscoreSavePath);
            var data = JsonUtility.FromJson<ScoreData>(json);

            Highscore = data;
        }
    }
}