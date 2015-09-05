using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D myRB;
	
	public float jumpForce = 10f;
	public float initialJumpForce = 100f;
	private float elapsedTime = 0f;
	public float maxExtraJump = 5f;

	private bool amIgrounded = false;
	

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
			if(amIgrounded == false)
			{
			myRB.AddForce(new Vector2(0,jumpForce+(elapsedTime)));
			}
			else
			{
			myRB.AddForce(new Vector2(0,initialJumpForce));
				Debug.Log("DOING IT");
			}
		}
		if (amIgrounded == false && !Input.GetKey(KeyCode.Space))
		{
			elapsedTime = maxExtraJump;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "TestFloor")
		{
			amIgrounded = true;
			elapsedTime = 0;
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.name == "TestFloor")
		{
			amIgrounded = false;
		}
	}

	void GetButtonInput ()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			elapsedTime += Time.deltaTime*20;
		}
	}

	void GetTheComponents()
	{
		myRB = GetComponent<Rigidbody2D>();
	}

}
