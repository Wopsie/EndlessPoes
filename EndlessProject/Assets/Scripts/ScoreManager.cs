using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public int myScore = 0;
	public int easyTimer = 0;
	public Text textForScore;

	// Use this for initialization
	void Start () {
		textForScore.text = "Score: "+myScore;
	}
	
	// Update is called once per frame
	void Update () {
		easyTimer++;
		if(easyTimer%100==1&&easyTimer!=0)
		{
			myScore+=100;
			textForScore.text = "Score: "+myScore;
		}
	}

	public void GetPointup(){
		myScore+=500;
		textForScore.text = "Score: "+myScore;
	}
}
