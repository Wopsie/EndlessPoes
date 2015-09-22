using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	private bool playerIsAlive = true;

	public static ScoreManager Instance;

	public int myScore = 0;
	public int easyTimer = 0;
	public int highScore = 10000;
	
	public Text textForScore;
	public Text textForHiScore;
	public Text gameOverText;

	public AudioSource pointAudio;
	public AudioSource gameOverAudio;

	// Use this for initialization
	void Start () {
		//Get UI elements
		textForScore.text = "Score: "+myScore;
		textForHiScore.text = "High Score:"+highScore;
		gameOverText.text = "";
	}
	
	void Update () {
		//Add 100 score every few seconds
		if(playerIsAlive == true)
		{
		easyTimer++;
		if(easyTimer%100==1&&easyTimer!=0)
		{
			myScore+=100;
			textForScore.text = "Score: "+myScore;
		}
		}
		//Q to quit, R to reset
		if(Input.GetKey(KeyCode.Q))
		{
			Application.Quit();
		}
		if(Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void GetPointup(){
		//Extra score (no sound)
		myScore+=500;
		textForScore.text = "Score: "+myScore;
	}

	public void GetPointupPickup()
	{
		//Extra score with sound
		pointAudio.Play();
		GetPointup();
	}

	public void UpdateHighScore(){
		//Game over
		gameOverText.text = "Press R to retry or press Q to quit";
		playerIsAlive = false;
		gameOverAudio.Play();
		if(myScore>highScore)
		{
			textForScore.text = "New High Score!";
			highScore = myScore;
			textForHiScore.text = "High Score: "+highScore;

		}
	}
}
