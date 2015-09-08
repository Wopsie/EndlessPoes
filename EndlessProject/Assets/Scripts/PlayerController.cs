using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public ScoreManager myManager;
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

	void Update()
	{

	}
	
	void FixedUpdate()
	{
		ElapsedTimeManager();
		GetButtonInput();
		if(amIgrounded == false)
		{
			if(Mathf.Approximately(0,myRB.velocity.y))
			{
			amIgrounded = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "GroundFloor")
		{
			amIgrounded = true; 
			elapsedTime = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "BonusPoints")
		{
			myManager.GetPointup();
			Destroy(other.gameObject);
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.tag == "GroundFloor")
		{
			amIgrounded = false;
			elapsedTime = 0;
			myRB.AddForce(new Vector2(0,initialJumpForce/100));
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
				amIgrounded = false;
			}
			else
			{
				myRB.AddForce(new Vector2(0,initialJumpForce));
			}
		}
	}

	void ElapsedTimeManager()
	{
		if((elapsedTime > maxExtraJump))
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
