using UnityEngine;
using System.Collections;

public class PointUp : Obstacle {
	//public float moveSpeed = 10f;
    /*
    private float randomHeight = Random.Range(-6.4f, 0f);
	void Start () 
    {
        transform.position.y = randomHeight;
	}
	*/
	// Update is called once per frame

    void FixedUpdate()
    {
        ObjMovement();
    }
}
