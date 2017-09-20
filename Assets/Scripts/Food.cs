using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour {
    private int m_State=0;
    private int[] States = { 0,1,2,3,4};
    private Slider foodTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int  GetState()
    {
        return m_State;
    }
    public void SetState(int index)
    {
        m_State = States[index];
        //Debug.Log("setState");
    }
    public void ProState()
    {
        if (m_State < 5)
        {
            m_State++;
        }
        
    }
    public Slider NewFoodTimer()
    {
        //foodTimer=TimerManager.Instance.NewTimer();
        
        return foodTimer;
       
    }
    public void TimerFllow()
    {
        foodTimer.transform.position = Camera.main.WorldToScreenPoint(this.transform.position) + new Vector3(0, 20, 5);
        //Debug.Log("foodTimer");
    }


}
