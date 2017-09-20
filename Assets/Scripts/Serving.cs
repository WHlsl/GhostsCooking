using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serving : MonoBehaviour {
    
    public KeyCode B1_Button;
    public KeyCode B2_Button;
    public Transform ServePositon;
    private Transform hadDish;
    
    private int foodCount=0;
    private int cabbageCount = 0;
    private int carrotCount = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player1"&& Input.GetKeyDown(B1_Button))||(other.tag == "Player2" && Input.GetKeyDown(B2_Button)))
        {
            other.GetComponent<Animator>().SetBool("isDuancai", false);
            if (!other.GetComponent<PlayerController>().IsHoldDish)
            {
                //提示需要盘子
                SoundManager.Instance.PlaySoundAtPosition("warning", ServePositon.position);
                return;
            }
            Transform[] sons = other.GetComponentsInChildren<Transform>();
            foreach (Transform trans in sons)
            {
                if (trans.tag == "Dish")
                {
                    SoundManager.Instance.PlaySoundAtPosition("addPoints", ServePositon.position);
                    hadDish = trans;
                    trans.SetParent(null);
                    trans.SetParent(ServePositon);
                    trans.localPosition = Vector3.zero;
                    Invoke("DestoryDish", 2);
                    other.GetComponent<PlayerController>().IsHold = false;
                    other.GetComponent<PlayerController>().IsHoldDish = false;

                }
                if(trans.tag== "UntreatedFood1")
                {
                    
                    foodCount++;
                    cabbageCount++;
                }
                if(trans.tag == "UntreatedFood2")
                {
                    
                    foodCount++;
                    carrotCount++;
                }
            }
        }
            
       
        

    }
    public int GetServedCount()
    {
        return foodCount;
    }
    public int GetCabbageCount()
    {
        return cabbageCount;
    }
    public int GetCarrotCount()
    {
        return carrotCount;
    }
    public void ResetServedCount()
    {
        foodCount = 0;
    }
    public void ResetCabbageCount()
    {
        cabbageCount = 0;
    }
    public void ResetCarrotCount()
    {
        carrotCount = 0;
    }
    public void DestoryDish()
    {
        Destroy(hadDish.gameObject);
    }

}
