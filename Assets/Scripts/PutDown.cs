using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PutDown : MonoBehaviour {
    public Transform borad;
    public Transform hand;
    public KeyCode B_Button;
    public KeyCode A_Button;
    public KeyCode X_Button;
    private bool isPutDown;
    public Slider TimerSlider;
    private Slider timer = null;
    public Canvas canvas;
    //private bool IsTimerOver=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            if (Input.GetKeyDown(B_Button))
            {
                Transform[] sons = other.GetComponentsInChildren<Transform>();
                foreach(Transform trans in sons)
                {
                    if ((trans.tag == "UntreatedFood1"&&gameObject.name== "treatingCollider1")
                        ||(trans.tag == "UntreatedFood2" && gameObject.name == "treatingCollider2"))
                    {
                        trans.SetParent(null);
                        trans.SetParent(borad);
                        trans.localPosition = Vector3.zero;
                        
                        
                        
                     
                    }
                    
                }
                //untreadFood.localPosition = Vector3.zero;
                //Debug.Log("putdown");
            }
            if (Input.GetKey(X_Button))
            {
                if (timer = null)
                {
                    timer = Instantiate(TimerSlider, Camera.main.WorldToScreenPoint(borad.position + new Vector3(0, 0, 1)), Quaternion.identity);
                    timer.transform.SetParent(canvas.transform);
                }
                else
                {
                    timer.GetComponent<Timer>().TimerRestart();
                }
                
                if (Input.GetKeyUp(X_Button))
                {
                    timer.GetComponent<Timer>().TimerPause();

                }
                Transform[] food = borad.GetComponentsInChildren<Transform>();
                if (food.Length > 0)
                {
                    foreach (Transform trans in food)
                    {
                        if (trans.tag == "UntreatedFood1" || trans.tag == "UntreatedFood2")
                        {
                            if (timer.GetComponent<Timer>().GetIsTime())
                            {
                                timer = null;
                                trans.GetComponent<Food>().SetState(1);
                            }
                           

                        }

                    }
                }
                
                //Debug.Log(trans.GetComponent<Food>().GetState());
                //IsTimerOver = false;
            }
            if (Input.GetKeyDown(A_Button))
            {
                Transform[] food = borad.GetComponentsInChildren<Transform>();
                if (food.Length > 0)
                {
                    foreach(Transform trans in food)
                    {
                        if (trans.tag == "UntreatedFood1"||trans.tag== "UntreatedFood2")
                        {
                            
                            trans.SetParent(null);
                            trans.SetParent(hand);
                            trans.localPosition = Vector3.zero;
                        }
                            
                    }
                }
            }
        }
    }
}
