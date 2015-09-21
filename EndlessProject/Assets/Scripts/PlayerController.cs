using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public ScoreManager myManager;
	public Transform fallingDead;
	private Rigidbody2D myRB;
	private Animator animator;

	private float elapsedTime = 0f;
	public float jumpForce = 10f;
	public float initialJumpForce = 100f;
	public float maxExtraJump = 5f;

	private bool amIgrounded = false;
	private bool doIHavePowerUp = false;

	public Vector2 respawnPosition;

    public AudioSource jumpAudio;
	public AudioSource powerUpAudio;

    //use this to play jumpsound
    //  jumpAudio.Play();

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
			if(amIgrounded == false && myRB.velocity.y<0)
			{
				myManager.GetPointup();
				Instantiate(fallingDead, col.gameObject.transform.position, Quaternion.identity);
				Destroy(col.gameObject);
				myRB.AddForce(new Vector2(0,initialJumpForce*3.5f));
			}
			else
			{
				if(doIHavePowerUp == true)
				{
					doIHavePowerUp = false;
					animator.SetBool("PowerUpAniState", false);
					Instantiate(fallingDead, col.gameObject.transform.position, Quaternion.identity);
					Destroy(col.gameObject);
				}
				else if(doIHavePowerUp == false)
				{
					PlayerDeath();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "BonusPoints")
		{
			myManager.GetPointupPickup();
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "PowerUp")
		{
			Destroy(other.gameObject);
			if(doIHavePowerUp == false)
			{
				doIHavePowerUp = true;
				animator.SetBool("PowerUpAniState",true);
				powerUpAudio.Play();
			}
			else if (doIHavePowerUp == true)
			{
				myManager.GetPointupPickup();
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
				jumpAudio.Play();
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
		Destroy(this.gameObject);
		myManager.UpdateHighScore();
	}

	void GetTheComponents()
	{
		animator = GetComponent<Animator>();
		myRB = GetComponent<Rigidbody2D>();
	}

}
