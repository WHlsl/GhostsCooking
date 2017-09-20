using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour {
    //public GameObject Player;
    public  Transform player1Hand;
    public Transform player2Hand;
    public Transform baket;
    public KeyCode B1_Button;
    public KeyCode B2_Button;
    public KeyCode A1_Button;
    public KeyCode A2_Button;
    public GameObject untreatedFood1;
    private GameObject holdOn;
    private Vector3 distance;
    //private HingeJoint hingeJoint;
   
    private Transform hadFood=null;
	// Use this for initialization
	void Start () {
        
        //hingeJoint = GetComponent<HingeJoint>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    void FixedUpdate()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1")
        {
            if (Input.GetKeyDown(A1_Button) && other.GetComponent<PlayerController>().IsHold == false)
            {
                other.GetComponent<Animator>().SetBool("isDuancai", true);
                SoundManager.Instance.PlaySoundAtPosition("hold", baket.position);
                if(hadFood == null)
                {
                    holdOn = Instantiate(untreatedFood1, player1Hand.position, Quaternion.identity);
                    holdOn.transform.SetParent(player1Hand);
                    other.GetComponent<PlayerController>().IsHold = true;
                    //Debug.Log("生成");

                }
                else
                {
                    hadFood.SetParent(null);
                    hadFood.SetParent(player1Hand);
                    hadFood.localPosition = Vector3.zero;
                    hadFood = null;
                }
                //Debug.Log("hold");
            }
            if (Input.GetKeyDown(B1_Button))
            {
                SoundManager.Instance.PlaySoundAtPosition("hold", baket.position);
                other.GetComponent<Animator>().SetBool("isDuancai", false);
                if (!(hadFood == null))
                {
                    return;
                }
                else
                {
                    Transform[] sons = other.GetComponentsInChildren<Transform>();
                    foreach (Transform trans in sons)
                    {
                        if (trans.tag == "UntreatedFood1" 
                            || trans.tag == "UntreatedFood2")
                        {
                            hadFood = trans;
                            trans.SetParent(null);
                            trans.SetParent(baket);
                            trans.localPosition = Vector3.zero;
                            other.GetComponent<PlayerController>().IsHold = false;
                            holdOn = null;

                        }

                    }
                }
            }
        }
        if (other.tag == "Player2")
        {
            if (Input.GetKeyDown(A2_Button) && other.GetComponent<PlayerController>().IsHold == false)
            {
                SoundManager.Instance.PlaySoundAtPosition("hold", baket.position);
                other.GetComponent<Animator>().SetBool("isDuancai", true);
                if (hadFood == null)
                {
                    holdOn = Instantiate(untreatedFood1, player2Hand.position, Quaternion.identity);
                    holdOn.transform.SetParent(player2Hand);
                    other.GetComponent<PlayerController>().IsHold = true;
                }
                else
                {
                    hadFood.SetParent(null);
                    hadFood.SetParent(player2Hand);
                    hadFood.localPosition = Vector3.zero;
                    hadFood = null;
                    
                    //Debug.Log("hold");
                }

            }
            if (Input.GetKeyDown(B2_Button))
            {
                SoundManager.Instance.PlaySoundAtPosition("hold", baket.position);
                other.GetComponent<Animator>().SetBool("isDuancai", false);
                if (!(hadFood == null))
                {
                    return;
                }
                else
                {
                    Transform[] sons = other.GetComponentsInChildren<Transform>();
                    foreach (Transform trans in sons)
                    {
                        if (trans.tag == "UntreatedFood1"
                            || trans.tag == "UntreatedFood2")
                        {
                            hadFood = trans;
                            trans.SetParent(null);
                            trans.SetParent(baket);
                            trans.localPosition = Vector3.zero;
                            other.GetComponent<PlayerController>().IsHold = false;
                            holdOn = null;

                        }

                    }
                }
            }
        }
        //Debug.Log(other.tag);
    }
}
