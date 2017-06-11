using UnityEngine;
using System.Collections;

public class SaveLoad : MonoBehaviour {

    public static SaveLoad intance;

     string score = "0";

    void Awake()
    {
        intance = this;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveLevel()
    {
        PlayerPrefs.SetInt(score, 1);
    }

    public int LoadLevel()
    {
        return PlayerPrefs.GetInt(score);
    }
}
