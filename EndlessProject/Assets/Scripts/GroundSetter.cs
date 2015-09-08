using UnityEngine;
using System.Collections;

public class GroundSetter : MonoBehaviour {

    public float groundSpeed;
    public float groundRespawnCords;
    public float offScreenCords;
    private float currentGroundHeight = transform.position.y;
    //private number groundHeight = Random.Range(-7.72f,-2.03f);

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.Translate(Vector2.left * groundSpeed);

        var groundHeight = Random.Range(-7.72f, -1.8f);
        if (transform.position.x <= offScreenCords)
        {
            transform.position = new Vector3(groundRespawnCords, groundHeight, 0f);
            //transform.position = new Vector3((groundRespawnCords-offScreenCords), groundHeight, 0f);
            //transform.Translate(groundRespawnCords, groundHeight, 0f);
        }
	}
}