using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D myRB;
	
	public float jumpForce = 10f;
	private float elapsedTime = 0f;
	public float maxExtraJump = 5f;
	

	void Start () 
	{
		GetTheComponents();
	}

	void Update () 
	{
		GetButtonInput();
	}

	void FixedUpdate()
	{
		if(elapsedTime > maxExtraJump)
		{
			elapsedTime = maxExtraJump;
		}
		if (Input.GetKey(KeyCode.Space) && elapsedTime < maxExtraJump && myRB.velocity.y >= 0)
		{
			myRB.AddForce(new Vector2(0,jumpForce+(elapsedTime)));
		}
	}

	void GetButtonInput ()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			elapsedTime += Time.deltaTime*12;
		}
		else
		{
			if (myRB.velocity.y == 0)
			{
				elapsedTime = 0;
			}
		}
	}

	void GetTheComponents()
	{
		myRB = GetComponent<Rigidbody2D>();
	}

}
