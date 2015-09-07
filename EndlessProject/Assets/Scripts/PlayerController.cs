using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D myRB;

	private float elapsedTime = 0f;
	public float jumpForce = 10f;
	public float initialJumpForce = 100f;
	public float maxExtraJump = 5f;

	private bool amIgrounded = false;
	

	void Start () 
	{
		GetTheComponents();
	}
	
	void FixedUpdate()
	{
		GetButtonInput();
		ElapsedTimeManager();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "Ground")
		{
			amIgrounded = true; 
			elapsedTime = 0;
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.name == "Ground")
		{
			amIgrounded = false;
		}
	}

	void GetButtonInput ()
	{
		if (Input.GetKey(KeyCode.Space) && amIgrounded == false)
		{
			elapsedTime += Time.deltaTime*20;
		}
		if (Input.GetKey(KeyCode.Space) && elapsedTime < maxExtraJump && myRB.velocity.y >= 0)
		{
			if(amIgrounded == false)
			{
				myRB.AddForce(new Vector2(0,jumpForce+(elapsedTime)), ForceMode2D.Impulse);
			}
			else
			{
				myRB.AddForce(new Vector2(0,initialJumpForce));
			}
		}
	}

	void ElapsedTimeManager()
	{
		if(elapsedTime > maxExtraJump)
		{
			elapsedTime = maxExtraJump;
		}
		
		if (amIgrounded == false && !Input.GetKey(KeyCode.Space))
		{
			elapsedTime = maxExtraJump;
		}
	}

	void GetTheComponents()
	{
		myRB = GetComponent<Rigidbody2D>();
	}

}
