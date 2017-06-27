using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    public Transform canvas;
    public GameObject TaskBar;
    private GameObject[] TaskBars;
    private Vector2[] taskPosition;
    private ArrayList taskList=new ArrayList();
    private int i = 0;
    private float ScreenX=100.0f;
	// Use this for initialization
	void Start () {
        Instance = this;
        InvokeRepeating("Task", 0, 20.0f);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    public void Task()
    {
        GameObject task=Instantiate(TaskBar, new Vector2(0, i*ScreenX), Quaternion.identity);
        task.transform.SetParent(canvas);
        taskList.Add(task);
        i++;

    }
    public int GetTaskCount()
    {
        return i;
    }
    public void SetTaskCount()
    {
        i --;
    }
}
