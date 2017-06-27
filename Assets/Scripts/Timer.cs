using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float lifeTime = 5.0f;
    private float timer = 0.0f;
    private float lastTime;
    private bool IsTime = false;
    private bool IsPause = false;
    public Slider TimerSlider;
	// Use this for initialization
	void Start () {
        //TimerSlider=this.sli
        
    }
	
	// Update is called once per frame
	void Update () {
        if (timer < lifeTime && !IsPause)
        {
            timer += Time.deltaTime;
            
        }
        if (timer > lifeTime)
        {
            IsTime = true;
            Invoke("DestroyTimer", 1.0f);
            //Debug.Log(IsTime);
        }
        TimerSlider.value = timer / lifeTime;
        //Debug.Log(timer);

    }
   
    public bool GetIsTime()
    {
        return IsTime;
    }
    public void TimerPause()
    {
        IsPause = true;
    }
    public void TimerRestart()
    {
        IsPause = false;
    }
    public void TimerReset()
    {
        timer = 0.0f;
    }
    public void DestroyTimer()
    {
        Destroy(gameObject);
    }
}
