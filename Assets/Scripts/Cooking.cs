using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour {
    private int greenCount = 0;
    private int yellowCount = 0;
    
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public int GetCookingCount()
    {
        return greenCount + yellowCount;
    }
    public int GetGreenCount()
    {
        return greenCount;
    }
    public void AddGreenCount(int num)
    {
        greenCount = greenCount + num;
        //Debug.Log(greenCount);
    }
    public int GetYellowCount()
    {
        return yellowCount;
    }
    public void AddYellowCount(int num)
    {
        yellowCount = yellowCount + num;
    }
    public void ResetGreenCount()
    {
        greenCount = 0;
    }
    public void ResetYellowCount()
    {
        yellowCount = 0;
    }
}
