using UnityEngine;
using System.Collections;

public class GroundEnemyPlacing : GroundSetter
{

    //private float gEnemyRespawncords = groundHeight + 6f;
    private float gEnemyOffScreenCords = Random.Range(-12.3f, -50f);
    private float groundEnemySpeed = 0.3f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.Translate(Vector2.left * groundEnemySpeed);

        
	}
}
