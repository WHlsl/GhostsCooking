using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static Score Instance;
    public Text scoreText;
    private int score = 0;
    public int lowScore = 1;
    public int midScore = 2;
	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "score:" + score;
    }
    public int GetScore()
    {
        return score;
    }
    public void AddLowScore()
    {
        score = score + lowScore;
        
        
    }
    public void AddMidScore()
    {
        score = score + midScore;

       
    }
    public void DeleteLowScore()
    {
        score = score -lowScore;
        if (score < 0)
        {
            score = 0;
        }
        
    }
}
