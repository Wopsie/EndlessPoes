﻿using UnityEngine;
using System.Collections;

public class PowerUpScript : Obstacle
{
    private float powerUpOffScreenCords = -24f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        ObjMovement();
	}
}
