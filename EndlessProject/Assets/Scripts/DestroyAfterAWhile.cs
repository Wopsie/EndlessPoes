using UnityEngine;
using System.Collections;

public class DestroyAfterAWhile : MonoBehaviour 
{
    //script making the dead enemy dissapear after its fallen for a certain time
	float timeLeft = 1f;
	void Update () 
    {
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			Destroy(this.gameObject);
		}
    }
}
