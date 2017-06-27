using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour {
    //public GameObject Player;
    public  Transform player1Hand;
    public Transform player2Hand;
    public KeyCode A1_Button;
    public KeyCode A2_Button;
    public GameObject untreatedFood1;
    private GameObject holdOn;
    private Vector3 distance;
    //private HingeJoint hingeJoint;
    private bool isHold=false;
	// Use this for initialization
	void Start () {
        
        //hingeJoint = GetComponent<HingeJoint>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    void FixedUpdate()
    {
        if (isHold)
        {
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1")
        {
            if (Input.GetKeyDown(A1_Button))
            {
                
                holdOn=Instantiate(untreatedFood1, player1Hand.position, Quaternion.identity);
                holdOn.transform.SetParent(player1Hand);
                isHold = true;
                //Debug.Log("hold");
            }
            
        }
        if (other.tag == "Player2")
        {
            if (Input.GetKeyDown(A2_Button))
            {

                holdOn = Instantiate(untreatedFood1, player2Hand.position, Quaternion.identity);
                holdOn.transform.SetParent(player2Hand);
                isHold = true;
                //Debug.Log("hold");
            }
        }
        //Debug.Log(other.tag);
    }
}
