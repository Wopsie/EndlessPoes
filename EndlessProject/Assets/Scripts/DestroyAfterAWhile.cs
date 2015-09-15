using UnityEngine;
using System.Collections;

public class DestroyAfterAWhile : MonoBehaviour {
	float timeLeft = 1f;
	void Update () {
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			Destroy(this.gameObject);
		}
}
}
