using UnityEngine;
using System.Collections;

public class GroundEnemyPlacing : MonoBehaviour
{

    private float gEnemyOffScreenCords = -24f;
    private float groundEnemySpeed = 0.4f;
    
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.Translate(Vector2.left * groundEnemySpeed);  
        if(transform.position.x <= gEnemyOffScreenCords)
        {
            Destroy(gameObject);
        }
	}

    
}
