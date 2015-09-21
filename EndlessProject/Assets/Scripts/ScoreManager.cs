using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	private bool playerIsAlive = true;
	public int myScore = 0;
	public int easyTimer = 0;
	public int highScore = 10000;
	
	public Text textForScore;
	public Text textForHiScore;
	

	// Use this for initialization
	void Start () {
		textForScore.text = "Score: "+myScore;
		textForHiScore.text = "High Score:"+highScore;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerIsAlive == true)
		{
		easyTimer++;
		if(easyTimer%100==1&&easyTimer!=0)
		{
			myScore+=100;
			textForScore.text = "Score: "+myScore;
		}
		}
	}

	public void GetPointup(){
		myScore+=500;
		textForScore.text = "Score: "+myScore;
	}

	public void UpdateHighScore(){
		if(myScore>highScore)
		{
			textForScore.text = "New High Score!";
			highScore = myScore;
			textForHiScore.text = "High Score: "+highScore;
			playerIsAlive = false;

		}
	}
}
