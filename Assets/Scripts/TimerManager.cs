using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {
    public static TimerManager Instance;
    public Slider timerSlider;
    public Canvas canvas;
    public Text time;
    public float totalTime=180;
    public bool IsTimeEnd = false;
	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if ((int)totalTime > 0)
        {
            InvokeRepeating("CountTime", 0, 1);
            totalTime -= Time.deltaTime;
        }
        else
        {
            IsTimeEnd = true;
        }
        
	}
    public Slider NewTimer(Vector3 fllowPosition, bool IsDestroy)
    {
        Slider t=Instantiate(timerSlider);
        if (IsDestroy)
        {
            t.GetComponent<Timer>().IsDestroyInMinute = true;
        }
        else
        {
            t.GetComponent<Timer>().IsDestroyInMinute = false;
        }
        t.transform.SetParent(canvas.transform);
        t.transform.position = Camera.main.WorldToScreenPoint(fllowPosition) + new Vector3(0, 20, 5);
        return t;
    }
    public Slider NewRedTimer(Vector3 fllowPosition,bool IsDestroy)
    {
        Slider t = Instantiate(timerSlider);
        if (IsDestroy)
        {
            t.GetComponent<Timer>().IsDestroyInMinute = true;
        }
        else
        {
            t.GetComponent<Timer>().IsDestroyInMinute = false;
        }
        t.transform.SetParent(canvas.transform);
        t.transform.position = Camera.main.WorldToScreenPoint(fllowPosition) + new Vector3(0, 20, 5);
        return t;
    }
    public void CountTime()
    {
        time.text = "Time " + (int)totalTime / 60 + ":" + (int)totalTime % 60/10+ (int)totalTime % 60%10;
        //Debug.Log("showtime");
    }
}
