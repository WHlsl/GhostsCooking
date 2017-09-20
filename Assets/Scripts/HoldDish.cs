using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDish : MonoBehaviour
{
    public Transform player1Hand;
    public Transform player2Hand;
    //public Transform baket;
    //public KeyCode B1_Button;
    //public KeyCode B2_Button;
    public KeyCode A1_Button;
    public KeyCode A2_Button;
    public GameObject dish;
    private GameObject holdOn;
    private Vector3 distance;
    //private HingeJoint hingeJoint;
    
    //private Transform hadFood = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1")
        {
            if (Input.GetKeyDown(A1_Button) && other.GetComponent<PlayerController>().IsHold== false)
            {

                other.GetComponent<Animator>().SetBool("isDuancai", true);
                SoundManager.Instance.PlaySoundAtPosition("hold", player1Hand.position);
                holdOn = Instantiate(dish, player1Hand.position, Quaternion.identity);
               holdOn.transform.SetParent(player1Hand);
                other.GetComponent<PlayerController>().IsHold = true;
                other.GetComponent<PlayerController>().IsHoldDish = true;
                //Debug.Log("hold");
            }
        }
        if (other.tag == "Player2")
        {
            if (Input.GetKeyDown(A2_Button) && other.GetComponent<PlayerController>().IsHold == false)
            {
                other.GetComponent<Animator>().SetBool("isDuancai", true);
                SoundManager.Instance.PlaySoundAtPosition("hold", player2Hand.position);
                holdOn = Instantiate(dish, player2Hand.position, Quaternion.identity);
                holdOn.transform.SetParent(player2Hand);
                other.GetComponent<PlayerController>().IsHold = true;
                other.GetComponent<PlayerController>().IsHoldDish = true;
                //Debug.Log("hold");
            }
        }
    }
}
