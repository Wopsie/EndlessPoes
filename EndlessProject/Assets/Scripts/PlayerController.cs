using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float jumpForce = 10f;
	private Rigidbody2D myRB;
	// Use this for initialization
	void Start () 
	{
		GetTheComponents();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetButtonInput();
	}

	void GetButtonInput ()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			//this.myRB.AddForce (Vector2.up * jumpForce);
		}
	}

	void GetTheComponents()
	{
		myRB = GetComponent<Rigidbody2D>();
	}

}
