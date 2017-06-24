using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float force = 200f;
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
        rb = GetComponent<Rigidbody>();
        //rangeRb2D = GetComponentInParent<Rigidbody2D>();
        minSpeed = -maxSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
	}
    private void Movement()
    {
        //movement
        float h = Input.GetAxis(PH);
        float v = Input.GetAxis(PV);
        rb.AddForce(new Vector3(h * force,0, v * force));
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, minSpeed, maxSpeed),
                                  0,
                                  Mathf.Clamp(rb.velocity.z, minSpeed, maxSpeed));

        //Debug.Log ("Velocity = " + rb2D.velocity);

    }
}
