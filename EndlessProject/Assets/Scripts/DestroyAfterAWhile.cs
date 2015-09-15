using UnityEngine;
using System.Collections;

public class DestroyAfterAWhile : MonoBehaviour {
	float timeLeft = 1f;
	void Update () {
		Debug.Log(timeLeft);
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			Destroy(this.gameObject);
		}
}
}
