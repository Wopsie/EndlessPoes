﻿using UnityEngine;
using System.Collections;

public class PointUp : Obstacle {
	//public float moveSpeed = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * obstacleSpeed);
        if(transform.position.x <= -24)
        {
            Destroy(gameObject);
        }
    }
}
