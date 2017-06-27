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
        
	}
    public int GetScore()
    {
        return score;
    }
    public void AddLowScore()
    {
        score = score + lowScore;
        
        scoreText.text = "score:" + score;
    }
    public void AddMidScore()
    {
        score = score + midScore;

        scoreText.text = "score:" + score;
    }
    public void DeleteLowScore()
    {
        score = score -lowScore;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "score:" + score;
    }
}
