using UnityEngine;
using System.Collections;

public class Crate : Obstacle {

    private float crateOffScreenCords = -24f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        ObjMovement();
	}
}
