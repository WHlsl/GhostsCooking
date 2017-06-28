using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPool : MonoBehaviour {

    private GameObject[] tasks;
    public GameObject taskPrefab;
    public GameObject horizontalParent;
    public int needCount = 3;
    public int MaxTaskCount = 5;
    private int needGreenCount;
    private int needYellowCount;
    public void NewTask()
    {
        int i = 0;
        needGreenCount = Random.Range(0, 3);
        needYellowCount = needCount - needGreenCount;
        if (i < MaxTaskCount&&)
        {
            tasks[i]=Instantiate(taskPrefab);
            tasks[i].transform.SetParent(horizontalParent.transform);
            i++;
        }
        
        
        
    }
}
