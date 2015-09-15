using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour
{
    public GameObject enemy;
    public GameObject pointUp;
    public GameObject crate;
    public GameObject powerup;
    //public GameObject platform;

    public float objOffScreenCords = -24f;
    
    public enum Spawns
    {
        PowerUp,
        ExtraPoints,
        Crate,
        Enemy
        //Platform,
        //Bird
    }

    public Dictionary<Spawns, GameObject> map = new Dictionary<Spawns, GameObject>();
    private Spawns spawns;
    public float obstacleSpeed = 0.3f;
    private int i;

    // Use this for initialization
    void Start()
    {
        map.Add(Spawns.Enemy, enemy);
        map.Add(Spawns.ExtraPoints, pointUp);
        map.Add(Spawns.Crate, crate);
        map.Add(Spawns.PowerUp, powerup);
        //map.Add(Spawns.Platform, platform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //time between spawns
        if (i >= 60)
        {
            Spawner();
            i = 0;
        }
        else
        {
            i++;
        }
    }

    void Spawner()
    {
        //spawns = Spawns.Enemy;
        spawns = (Spawns)Random.Range(0, 4);
        var clone = (GameObject) Instantiate(map[spawns], transform.position, Quaternion.identity);

        switch(clone.Tag)
        {
            case clone.BonusPoints:
                transform.position.y = Random.Range(-6.4, 0);
            break;
            case clone.PowerUp:
                transform.position.y = Random.Range(-6.4, 0);
            break;

        }
    }

    public void ObjMovement()
    {
        transform.Translate(Vector2.left * obstacleSpeed);
        if (transform.position.x <= objOffScreenCords)
        {
            Destroy(gameObject);
        }
    }
}