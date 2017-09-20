using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float lifeTime = 5.0f;
    private float timer = 0.0f;

    public bool IsTime { get; set; }

    public bool IsDestroyInMinute { get; set; }
    //private bool IsTime = false;
    private bool IsPause = false;
    public Slider TimerSlider;

    //private bool IsHalfTime = false;
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
        if ((timer > lifeTime)&& (!IsTime))
        {
            IsTime = true;
            if (IsDestroyInMinute)
            {
                Invoke("DestroyTimer", 1.0f);
            }
            //Debug.Log(IsTime);
        }
       
        TimerSlider.value = timer / lifeTime;
        //Debug.Log(timer);

    }
   
   
    public void SetIsTime()
    {

    }
    public void TimerPause()
    {
        IsPause = true;
    }
    public void TimerRestart()
    {
        IsPause = false;
    }
    public void DeleteTime(float delelteTime)
    {
        timer -= delelteTime;
        if (timer < 0)
        {
            timer = 0;
        }
        
    }
    public void TimerReset()
    {
        IsTime = false;
        timer = 0.0f;
    }
   
    public void DestroyTimer()
    {
        Destroy(gameObject);
    }
    
}
