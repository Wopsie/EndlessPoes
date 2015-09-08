using UnityEngine;
using System.Collections;

public class Parallaxer : MonoBehaviour 
{
    public float buildingSpeed;
    public float bgRespawnCords = 12.6f;
    public float offScreenCords;

    void FixedUpdate()
    {
        //transform.position = new Vector2()
        transform.Translate(Vector2.left * buildingSpeed);
        //Debug.Log(transform);
        //Debug.Log(transform.position.x);
        if(transform.position.x <= offScreenCords)
        {
            transform.position = new Vector3(bgRespawnCords, -1.22f, 0f);
        }
    }

    void Update()
    {

    }
}
