using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutDowmPan : MonoBehaviour {
    public KeyCode B_Button1;
    public KeyCode B_Button2;
    public KeyCode A_Button1;
    public KeyCode A_Button2;
    public Transform pan;
    public Slider TimerSlider;
    public Transform canvas;
    private Slider timer;
    //private Slider timer2;
    private Transform HasDish;
    private int foodCount=0;
    private int oldCount = 1;
    public ParticleSystem Smoke;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
      
        if (!(timer==null)&&timer.GetComponent<Timer>().IsTime)
        {
            timer.fillRect.GetComponent<Image>().color = Color.red;
            timer.GetComponent<Timer>().TimerPause();
            //Invoke("Warning", 2.0f);
            Food[] foodInPan = pan.GetComponentsInChildren<Food>();
            foreach (Food f in foodInPan)
            {

                f.SetState(2);
                
            }
            Invoke("OverCooked", 8.0f);
        }
     
                
    
           
        
        
	}
    public void Warning()
    {
        SoundManager.Instance.PlaySoundAtPosition("warning", pan.position);
    }
    public void OverCooked()
    {
        Food[] foodInPan = pan.GetComponentsInChildren<Food>();
        foreach (Food f in foodInPan)
        {

            f.SetState(3);

        }
        Smoke.gameObject.SetActive(true);
        
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player1" &&Input.GetKeyDown(B_Button1) )||( other.tag == "Player2"&& Input.GetKeyDown(B_Button2))&&foodCount<4&& (other.GetComponent<PlayerController>().IsHold))
        {
            other.GetComponent<PlayerController>().IsHold = false;
            SoundManager.Instance.PlaySoundAtPosition("hold", pan.position);
            other.GetComponent<Animator>().SetBool("isDuancai", false);
            Transform[] pans = pan.GetComponentsInChildren<Transform>();
            foreach(Transform p in pans)
            {
                if (p.tag == "panWithFood")
                {
                    p.GetComponent<MeshRenderer>().enabled = true;
                    //Debug.Log("pan");
                }
            }
            Transform[] sons = other.GetComponentsInChildren<Transform>();
            foreach (Transform trans in sons)
            {
                if (trans.tag == "UntreatedFood1")
                {

                    foodCount++;
                    trans.SetParent(null);
                    trans.SetParent(pan);
                    trans.localPosition = Vector3.zero;
                    //trans.GetComponentInChildren<MeshRenderer>().enabled = false;
                    if (timer == null)
                    {
                        timer = TimerManager.Instance.NewRedTimer(pan.position,false);
                        
                    }
                    else
                    {
                        timer.GetComponent<Timer>().lifeTime +=6;
                        timer.GetComponent<Timer>().IsTime = false;
                        timer.GetComponent<Timer>().TimerRestart();
                        timer.fillRect.GetComponent<Image>().color = Color.green;
                        Smoke.gameObject.SetActive(false);
                        CancelInvoke("OverCooked");
                    }
                    //timer1=Instantiate(TimerSlider, Camera.main.WorldToScreenPoint(pan.position + new Vector3(0, 0, 1)), Quaternion.identity);
                    //timer1.transform.SetParent(canvas);
                    //timer1.GetComponent<Timer>().TimerReset();

                    pan.GetComponent<Cooking>().AddGreenCount(1);
                    
                        
                        
                        //Debug.Log("putdown");
                }
                if (trans.tag == "UntreatedFood2")
                {
                    foodCount++;
                    trans.SetParent(null);
                   trans.SetParent(pan);
                   trans.localPosition = Vector3.zero;
                    //trans.GetComponentInChildren<MeshRenderer>().enabled = false;
                    if (timer == null)
                    {
                        timer = TimerManager.Instance.NewRedTimer(pan.position,false);
                    }
                    else
                    {
                        timer.GetComponent<Timer>().lifeTime += 6;
                        timer.GetComponent<Timer>().IsTime = false;
                        timer.GetComponent<Timer>().TimerRestart();
                        timer.fillRect.GetComponent<Image>().color = Color.green;
                        Smoke.gameObject.SetActive(false);
                        CancelInvoke("OverCooked");
                    }
                    pan.GetComponent<Cooking>().AddYellowCount(1);
                   
                }
            }
            
        }
        if ((other.tag == "Player1" && Input.GetKeyDown(A_Button1)) || (other.tag == "Player2" && Input.GetKeyDown(A_Button2)))
        {
            other.GetComponent<PlayerController>().IsHold = true;
            
            
            if (other.GetComponent<PlayerController>().IsHoldDish)
            {
                SoundManager.Instance.PlaySoundAtPosition("hold", pan.position);
                other.GetComponent<Animator>().SetBool("isDuancai", true);
                if (!(timer == null))
                {
                    timer.GetComponent<Timer>().DestroyTimer();
                    Smoke.gameObject.SetActive(false);
                    CancelInvoke("OverCooked");
                }
                Transform[] pans = pan.GetComponentsInChildren<Transform>();
                foreach (Transform p in pans)
                {
                    if (p.tag == "panWithFood")
                    {
                        p.GetComponent<MeshRenderer>().enabled = false;
                        //Debug.Log("pan");
                    }
                }
                Transform[] sons = other.GetComponentsInChildren<Transform>();
                foreach (Transform trans in sons)
                {
                    if (trans.tag == "Dish")
                    {
                        HasDish = trans;
                        MeshRenderer[] renderers = trans.GetComponentsInChildren<MeshRenderer>();
                        foreach(MeshRenderer mr in renderers)
                        {
                            if (mr.gameObject.tag=="dishWithFood")
                            {
                                mr.enabled = true;
                            }
                        }
                       
                       // Debug.Log("dishwithfood");
                    }
                }
                Transform[] food = pan.GetComponentsInChildren<Transform>();
                foreach(Transform f in food)
                {
                    if(f.tag== "UntreatedFood1"||f.tag== "UntreatedFood2")
                    {
                        foodCount--;
                        f.SetParent(HasDish);
                        f.localPosition = Vector3.zero;
                       // Debug.Log(f.name);
                    }
                    
                }
            }else
            {
                SoundManager.Instance.PlaySoundAtPosition("warning", pan.position);
            }
        }

    }
}
