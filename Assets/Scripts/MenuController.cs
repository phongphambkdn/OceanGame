using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    [SerializeField]
    private tk2dTextMesh highScoreText;

    void Start()
    {
        if (PlayGameController.pressBtn == true)
        {
            GetComponent<AudioSource>().Play(); PlayGameController.pressBtn = false;
        }
        highScoreText.text = "HIGH SCORE : " + ManagerGame.instance.GetHighScore();
    }
    public void _PlayButton()
    {
        PlayGameController.pressBtn = true;
        Application.LoadLevel("Main");
        
        

    }

    public void _TopScore()
    {
        GetComponent<AudioSource>().Play();
        //Application.LoadLevel("HighScore");
    }
    public void _ExitButton()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
