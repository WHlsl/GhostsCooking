using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPool : MonoBehaviour {

    public static TaskPool instance;
    private ArrayList taskList = new ArrayList();

    public GameObject taskPrefab;
    public GameObject horizontalParent;



    private void Start()
    {
        instance = this;
    }
    public GameObject GetTask()
    {
        GameObject go;
        int needGreenCount = Random.Range(0, 3);
        if (taskList.Count > 0)
        {
            go = (GameObject)taskList[0];
            taskList.RemoveAt(0);
            go.SetActive(true);
            go.GetComponent<LayoutElement>().ignoreLayout = false;
        }
        else
        {
            go = Instantiate(taskPrefab);
            go.transform.SetParent(horizontalParent.transform);
        }
        //go.GetComponent<Task>().SetNeedCount(needGreenCount);
        return go;


    }
    public void ReturnTask(GameObject g)
    {
        taskList.Add(g);
        g.SetActive(false);
        g.GetComponent<LayoutElement>().ignoreLayout = true;
        //g.transform.SetParent(null);
    }
}
