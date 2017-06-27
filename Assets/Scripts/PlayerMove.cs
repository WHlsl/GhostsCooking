using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private Transform trans;
    public float speed = 10f;
    
    //public float rangeForce = 5f;
    private Rigidbody rb;
    //private Rigidbody2D rangeRb2D;
    public float maxSpeed = 20f;
    private float minSpeed = 0;
    public AudioClip[] jumpSounds;
    public string PH;
    public string PV;
    // Use this for initialization
    void Start () {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        //rangeRb2D = GetComponentInParent<Rigidbody2D>();
        minSpeed = -maxSpeed;
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        //movement
        float h = Input.GetAxis(PH);
        float v = Input.GetAxis(PV);
        

        rb.velocity = new Vector3(h*speed, 0,v*speed);
        //Debug.Log(rb.velocity);
        Vector3 targetDirection = new Vector3(h, 0f, v);
        // 创建目标旋转值 并假设Y轴正方向为"上"方向
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up); //函数参数解释: LookRotation(目标方向为"前方向", 定义声明"上方向")
        // 创建新旋转值 并根据转向速度平滑转至目标旋转值
        //函数参数解释: Lerp(角色刚体当前旋转值, 目标旋转值, 根据旋转速度平滑转向)
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, speed * 0.5f*Time.deltaTime);
        // 更新刚体旋转值为 新旋转值
        rb.MoveRotation(newRotation);
        //Debug.Log(trans.rotation);
        //Debug.Log ("Velocity = " + rb2D.velocity);

    }
    
}
