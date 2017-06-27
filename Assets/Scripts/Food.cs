using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    private int m_State=0;
    private int[] States = { 0,1,2};
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
        Debug.Log("setState");
    }
}
