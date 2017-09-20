using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PutDown : MonoBehaviour {
    public Transform borad;
    public KeyCode B1_Button;
    public KeyCode B2_Button;
    public KeyCode A1_Button;
    public KeyCode A2_Button;
    public KeyCode X1_Button;
    public KeyCode X2_Button;
    private bool isPutDown;
    public Slider TimerSlider;
    private Slider timer = null;
    private Transform hadFood=null;
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
       
            if ((other.tag == "Player1"&&Input.GetKeyDown(B1_Button))|| (other.tag == "Player2"&&Input.GetKeyDown(B2_Button)))
            {
                other.GetComponent<PlayerController>().IsHold = false;
                SoundManager.Instance.PlaySoundAtPosition("hold", borad.position);
                if (!(hadFood == null))
                {
                    return;
                }
                else
                {
                other.GetComponent<Animator>().SetBool("isDuancai", false);
                Transform[] sons = other.GetComponentsInChildren<Transform>();
                    foreach (Transform trans in sons)
                    {
                        if ((trans.tag == "UntreatedFood1" && gameObject.name == "treatingCollider1")
                            || (trans.tag == "UntreatedFood2" && gameObject.name == "treatingCollider2"))
                        {
                            hadFood = trans;
                            trans.SetParent(null);
                            trans.SetParent(borad);
                            trans.localPosition = Vector3.zero;




                        }

                    }
                }
                
                
                //untreadFood.localPosition = Vector3.zero;
                //Debug.Log("putdown");
            }
            if ((other.tag == "Player1" && Input.GetKeyDown(X1_Button)) || (other.tag == "Player2" && Input.GetKeyDown(X2_Button)))
            {
                if (hadFood == null)
                {
                    return;
                }
                else
                {
                int foodState = 0;
                foodState = hadFood.GetComponent<Food>().GetState();
                if (foodState == 0)
                {
                    if (timer == null)
                    {
                        timer = TimerManager.Instance.NewTimer(borad.position, true);
                        timer.GetComponent<Timer>().lifeTime = 3.0f;
                        //hadFood.GetComponent<Food>().TimerFllow();
                        //Debug.Log("yellow");
                    }
                    else
                    {
                        timer.GetComponent<Timer>().TimerRestart();
                    }
                }
                }
                
               
            }
            if ((other.tag == "Player1" && Input.GetKey(X1_Button)) || (other.tag == "Player2" && Input.GetKey(X2_Button)))
            {
                if (timer == null)
                {
                    return;
                }
                //Debug.Log(timer.GetComponent<Timer>().GetIsTime());
                if (timer.GetComponent<Timer>().IsTime)
                {
                    hadFood.GetComponent<Food>().SetState(1);
                    Transform[] food = hadFood.GetComponentsInChildren<Transform>();
                    foreach(Transform f in food)
                    {
                        if (f.tag =="Untreated")
                        {
                            f.GetComponent<MeshRenderer>().enabled=false;
                            //Debug.Log("untreated");
                        }
                        if (f.tag =="Treated")
                        {
                            f.GetComponent<MeshRenderer>().enabled = true;
                            //Debug.Log("treated");

                        }
                        //Debug.Log("f");
                    }
                      
                                                                                
                }
                //Debug.Log("stay");
            }
            if ((other.tag == "Player1" && Input.GetKeyUp(X1_Button)) || (other.tag == "Player2" && Input.GetKeyUp(X2_Button)))
            {
                if (timer == null)
                {
                    return;
                }
                timer.GetComponent<Timer>().TimerPause();
                //Debug.Log("pause");

            }
            if ((other.tag == "Player1" && Input.GetKeyDown(A1_Button)) || (other.tag == "Player2" && Input.GetKeyDown(A2_Button)))
            {
                other.GetComponent<PlayerController>().IsHold = true;
                SoundManager.Instance.PlaySoundAtPosition("hold", borad.position);

            
                if (hadFood == null)
                {
                    return;
                }
                if (timer == null)
                {
                    other.GetComponent<Animator>().SetBool("isDuancai", true);
                    Transform[] sons = other.GetComponentsInChildren<Transform>();
                    foreach (Transform trans in sons)
                    {
                        if ((trans.tag == "Hand1"
                            || trans.tag == "Hand2" ))
                        {
                            hadFood.SetParent(null);
                            hadFood.SetParent(trans);
                            hadFood.localPosition = Vector3.zero;
                            hadFood = null;

                        }
                    }
                   
                }
            }
        
    }
    
}
