using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static string sceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadStartScene()
    {
        SceneManager.LoadScene("start");
    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("play");
    }
    public void LoadEndScene()
    {
        SceneManager.LoadScene("end");
    }
    public void LoadGuideScene()
    {
        SceneManager.LoadScene("guide");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
