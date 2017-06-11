using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayGameController : MonoBehaviour {
    public static PlayGameController instance;
    [SerializeField]
    private tk2dTextMesh scoreText,endscoreText,highscoreText;
    [SerializeField]
    private GameObject PanelScore,PanelPause;
    [SerializeField]
    private Button pause;
    public static bool pressBtn = false;
    void Awake()
    {
        if (pressBtn == true)
        {
            GetComponent<AudioSource>().Play(); pressBtn = false;
        }

        MakeInstance();
        Time.timeScale = 1;
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
	public void _PlayAgainButton()
    {
        pressBtn = true;
        Application.LoadLevel("Main");
        

    }
    public void _SetScore(int score)
    {
        scoreText.text = score.ToString();
        endscoreText.text = score.ToString();
    }
    public void _ShowPanelScore(int score)
    {
        PanelScore.SetActive(true);
        GameObject.Find("AudioDead").GetComponent<AudioSource>().Play();
       /*endscoreText.text = score.ToString();
        if (score > ManagerGame.instance.GetHighScore())
        {
            ManagerGame.instance.SetHighScore(score);
            highscoreText.text = "High Score !!!!!";
            endscoreText.text = "";
        }*/
    }
    public void _ButonExit()
    {
        pressBtn = true;
        Application.LoadLevel("Menu");
    }
    public void _ButtonPause()
    {
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
        PanelPause.SetActive(true);
        pause.gameObject.SetActive(false);
    }
    public void _ButtonResum()
    {
        GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        PanelPause.SetActive(false);
        pause.gameObject.SetActive(true);
    }
}
