using UnityEngine;
using System.Collections;

public class PowerUpScript : Obstacle
{
    private float powerUpOffScreenCords = -24f;

	void FixedUpdate () 
    {
        ObjMovement();
	}
}
