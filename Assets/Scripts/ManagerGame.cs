using UnityEngine;
using System.Collections;

public class ManagerGame : MonoBehaviour {

    public static ManagerGame instance;
    private const string HIGH_SCORE = "High Score";
    private const string SOUND = "Sound";
    
    void Awake()
    {
        _MakeSingleInstance();
    }
    void IsGameStartedForTheFirstGame()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstGame")){
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(SOUND, 1);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstGame", 0);
        }
    }
    void _MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE,score);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
    public void setSound(int sound)
    {
        PlayerPrefs.SetInt(SOUND, sound);
    }
    public int getSound()
    {
        return PlayerPrefs.GetInt(SOUND);
    }
}
