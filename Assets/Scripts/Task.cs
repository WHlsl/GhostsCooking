using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour {
    public GameObject pan;
    private Food[] cookingFood;
    private  Cooking cooking;
    public int Count = 3;
    private int needGreenCount;
    private int needYellowCount;

    private Text task;

	// Use this for initialization
	void Start () {
        cooking = pan.GetComponent<Cooking>();
        needGreenCount = Random.Range(0, 3);
        task = GetComponentInChildren<Text>();
        needYellowCount = Count - needGreenCount;
        //needYellowCount = 0;
        task.text = "绿：" + needGreenCount + " " + "黄：" + needYellowCount;

        

    }
	
	// Update is called once per frame
	void Update () {
        if (cooking.GetGreenCount() == needGreenCount && cooking.GetYellowCount() == needYellowCount)
        {
            cookingFood = pan.GetComponentsInChildren<Food>();
            foreach(Food f in cookingFood)
            {
                if (f.GetState() ==1)
                {
                    Score.Instance.AddMidScore();
                    f.SetState(2);
                }
                else
                {
                    Score.Instance.DeleteLowScore();
                    Debug.Log(Score.Instance.GetScore());
                    f.SetState(2);
                }
            }
            
            cooking.ResetGreenCount();
            cooking.ResetYellowCount();
            
            Invoke("DestroySelf",1);
        }
        Invoke("DestroyByTime", 30.0f);
	}
    public int GetNeedGreenCount()
    {
        return needGreenCount;
    }
    public int GetNeedYellowCount()
    {
        return needYellowCount;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void DestroyByTime()
    {
        Destroy(gameObject);
        //GameController.Instance.SetTaskCount();
    }
}
