using UnityEngine;
using System.Collections;

public class PointUp : MonoBehaviour {
	public float moveSpeed = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);

	}
}
