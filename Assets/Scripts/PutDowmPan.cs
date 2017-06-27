using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutDowmPan : MonoBehaviour {
    public KeyCode B_Button1;
    public KeyCode B_Button2;
    public Transform pan;
    public Slider TimerSlider;
    public Transform canvas;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            if (Input.GetKeyDown(B_Button1)||Input.GetKeyDown(B_Button2))
            {
                Transform[] sons = other.GetComponentsInChildren<Transform>();
                foreach (Transform trans in sons)
                {
                    if (trans.tag == "UntreatedFood1")
                    {
                        trans.SetParent(null);
                        trans.SetParent(pan);
                        trans.localPosition = Vector3.zero;
                        Slider timer=Instantiate(TimerSlider, Camera.main.WorldToScreenPoint(pan.position + new Vector3(0, 0, 1)), Quaternion.identity);
                        timer.transform.SetParent(canvas);
                        timer.GetComponent<Timer>().TimerReset();
                        
                        pan.GetComponent<Cooking>().AddGreenCount(1);
                        
                        
                        
                        //Debug.Log("putdown");
                    }
                    if (trans.tag == "UntreatedFood2")
                    {
                        trans.SetParent(null);
                        trans.SetParent(pan);
                        trans.localPosition = Vector3.zero;
                        Slider timer = Instantiate(TimerSlider, Camera.main.WorldToScreenPoint(pan.position + new Vector3(0, 0, 1)), Quaternion.identity);
                        timer.transform.SetParent(canvas);
                        timer.GetComponent<Timer>().TimerReset();

                        pan.GetComponent<Cooking>().AddYellowCount(1);
                    }
                }
            }
        }
    }
}
