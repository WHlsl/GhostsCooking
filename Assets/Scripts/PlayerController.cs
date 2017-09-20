using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
   
    public bool IsHold { get; set; }
    public bool IsHoldDish { get; set; }
	// Use this for initialization
	void Start () {
        IsHold = false;
        IsHoldDish = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
}
