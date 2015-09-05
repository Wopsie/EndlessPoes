using UnityEngine;
using System.Collections;

public class Parallaxer : MonoBehaviour 
{
    public float buildingSpeed = 1f;

    void FixedUpdate()
    {
        //transform.position = new Vector2()
        transform.Translate(Vector2.left * buildingSpeed);
        Debug.Log(transform);
        Debug.Log(transform.position.x);
    }

    void Update()
    {

    }
}
