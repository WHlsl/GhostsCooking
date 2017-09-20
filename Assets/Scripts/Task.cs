using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour {
    private GameObject servePosition;
    
    private Food[] servedFood;
    private Serving serving;
    public int Count = 3;
    private int needGreenCount;
    private int needYellowCount;

    private Text task;

    private Transform[] taskChildren;
    //public Image greenTask;
    //public Image yellowTask;
    public Image[] foodTask=new Image[2];
	// Use this for initialization
	void Start () {
        servePosition = GameObject.FindGameObjectWithTag("servedPosition");
        serving = GameObject.FindGameObjectWithTag("servingCollider").GetComponent<Serving>();

        taskChildren = GetComponentsInChildren<Transform>();
        //needGreenCount = Random.Range(0, 3);
        //task = GetComponentInChildren<Text>();
        //needYellowCount = Count - needGreenCount;
        //needYellowCount = 0;
        for(int i=1;i< Count+1; i++)
        {
            int foodIndex = Random.Range(0, foodTask.Length);
            Image ft = Instantiate(foodTask[foodIndex], taskChildren[i]);
            ft.transform.SetParent(taskChildren[i]);
            switch (foodIndex)
            {
                case 0:
                    needGreenCount++;
                    break;
                case 1:
                    needYellowCount++;
                    break;
                default:
                    break;
            }
            //greenTask.transform.SetParent(taskChildren[i]);
            //Debug.Log(taskChildren[i].name);

        }

        //task.text = "绿：" + needGreenCount + " " + "黄：" + needYellowCount;

        

    }
	
	// Update is called once per frame
	void Update () {
        if (serving.GetCabbageCount() == needGreenCount && serving.GetCarrotCount() == needYellowCount)
        {
            servedFood = servePosition.GetComponentsInChildren<Food>();
            foreach(Food f in servedFood)
            {
                if (f.GetState() ==2)
                {
                    Score.Instance.AddMidScore();
                    
                }
                else
                {
                    Score.Instance.AddLowScore();
                   // Debug.Log(Score.Instance.GetScore());
                    
                }
                Debug.Log(f.GetState());
            }
            serving.ResetServedCount();
            serving.ResetCabbageCount();
            serving.ResetCarrotCount();
            
            Invoke("DestroySelf",1);
        }
        Invoke("DestroyByTime", 40.0f);
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
        GameController.Instance.RemoveTask();
        //GameController.Instance.SetTaskCount();
    }
}
