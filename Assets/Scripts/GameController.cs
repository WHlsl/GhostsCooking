using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController Instance;
    public GameObject taskPrefab;
    public GameObject horizontalParent;
    //private ArrayList taskList;
    private GameObject[] tasks;
    private int taskCount = 0;
    private float timer = 0;
    private float lifeTime = 10.0f;
    public int MaxTaskCount = 5;

    private SceneController sc;
    // Use this for initialization
    void Start()
    {
        Instance = this;
        tasks = new GameObject[MaxTaskCount];
        //taskList = new ArrayList();
        tasks[0]=CreateTask();
        //InvokeRepeating("DestroyTask", 0, 30.0f);
        sc = GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
           
        
        if (taskCount > 0 && taskCount < MaxTaskCount)
        {
            timer += Time.deltaTime;
            if(timer> lifeTime)
            {
                for(int i = 0; i < MaxTaskCount; i++)
                {
                    if (tasks[i] == null)
                    {
                        tasks[i]=CreateTask();
                        break;
                        Debug.Log("create");
                    }
                }
                timer = 0;
            }

        }
        if (TimerManager.Instance.IsTimeEnd)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public GameObject CreateTask()
    {
        GameObject activeTask;
        activeTask = Instantiate(taskPrefab);

        activeTask.transform.SetParent(horizontalParent.transform);
        activeTask.transform.localScale = Vector3.one;
        taskCount++;
        return activeTask;
    }
    public void RemoveTask()
    {
        taskCount--;
    }
    public void GameOver()
    {
        sc.LoadEndScene();
    }
}
