using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public ScoreManager myManager;
	private Rigidbody2D myRB;
	private Animator animator;

	private float elapsedTime = 0f;
	public float jumpForce = 10f;
	public float initialJumpForce = 100f;
	public float maxExtraJump = 5f;

	private bool amIgrounded = false;
	private bool doIHavePowerUp = false;

	public Vector2 respawnPosition;

	void Start () 
	{
		GetTheComponents();
	}

	void FixedUpdate()
	{
		FallingCheck();
		ElapsedTimeManager();
		GetButtonInput();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "GroundFloor")
		{
			animator.SetBool("AmIGrounded",true);
			amIgrounded = true; 
			elapsedTime = 0;
		}

		if(col.gameObject.tag == "HurtPlayer")
		{
			if(doIHavePowerUp == true)
			{
				doIHavePowerUp = false;
				animator.SetBool("PowerUpAniState", false);
				Destroy(col.gameObject);
			}
			else if(doIHavePowerUp == false)
			{
				PlayerDeath();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "BonusPoints")
		{
			myManager.GetPointup();
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "PowerUp")
		{
			Destroy(other.gameObject);
			if(doIHavePowerUp == false)
			{
				doIHavePowerUp = true;
				animator.SetBool("PowerUpAniState",true);
			}
		}

		if(other.gameObject.tag == "InstaKillPlayer")
		{
			if(doIHavePowerUp == true)
			{
				doIHavePowerUp = false;
				animator.SetBool("PowerUpAniState", false);
				this.transform.position = respawnPosition;
			}
			else if(doIHavePowerUp == false)
			{
				PlayerDeath();
			}
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if(col.gameObject.tag == "GroundFloor")
		{
			animator.SetBool("AmIGrounded",false);
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

	void FallingCheck()
	{
		if(amIgrounded == false)
		{
			if(myRB.velocity.y<0)
			{
				animator.SetBool("AmIFalling",true);
			}
			else
			{
				animator.SetBool("AmIFalling", false);
			}
		}
	}

	void PlayerDeath()
	{
		//Player dies
		Destroy(this.gameObject);
	}

	void GetTheComponents()
	{
		animator = GetComponent<Animator>();
		myRB = GetComponent<Rigidbody2D>();
	}

}
