using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour
{
    public GameObject enemy;
    public GameObject pointUp;
    public GameObject crate;
    public GameObject powerup;
    public GameObject platform;

    private int powerSpawn;
    private int platformSpawn;

    public float objOffScreenCords = -24f;
    
    public enum Spawns
    {
        PowerUp,
        ExtraPoints,
        Crate,
        Enemy,
        Platform
    }

    public Dictionary<Spawns, GameObject> map = new Dictionary<Spawns, GameObject>();
    private Spawns spawns;
    public float obstacleSpeed = 0.3f;
    private int i;
    private Spawns rarity;
    private Spawns platSpawn;

    // Use this for initialization
    void Start()
    {
        map.Add(Spawns.Enemy, enemy);
        map.Add(Spawns.ExtraPoints, pointUp);
        map.Add(Spawns.Crate, crate);
        map.Add(Spawns.PowerUp, powerup);
        map.Add(Spawns.Platform, platform);
    }

    void FixedUpdate()
    {
        //time between spawns
        if (i >= 70)
        {
            Spawner();
            i = 0;
        }
        else
        {
            i++;
        }
    }

    //function that makes random objects spawn
    void Spawner()
    {
        spawns = (Spawns)Random.Range(0, 5);
        rarity = (Spawns)Random.Range(1, 5);
        platSpawn = (Spawns)Random.Range(1, 4);

        var clone = (GameObject)Instantiate(map[spawns], transform.position, Quaternion.identity);

        //counters and ifstatements for ajusting the rarity of powerups and platforms
        powerSpawn++;
        platformSpawn++;

        if(clone.tag == "PowerUp" && powerSpawn >= 12)
        {
            powerSpawn = 0;
        }else if(clone.tag == "PowerUp" && powerSpawn <= 12)
        {
            Destroy(clone);
            Instantiate(map[rarity], transform.position, Quaternion.identity);
        }

        if(clone.tag == "GroundFloor" && platformSpawn >= 4)
        {
            platformSpawn = 0;
        }else if(clone.tag == "GroundFloor" && platformSpawn <= 4)
        {
            Destroy(clone);
            Instantiate(map[platSpawn], transform.position, Quaternion.identity);
        }
        
        //randomize height of powerups and pickups
        switch(clone.tag)
        {
            case "BonusPoints":
                clone.transform.position = new Vector3(38f, Random.Range(-6.4f, 0f), 0f);
                break;

            case "PowerUp":
                clone.transform.position = new Vector3(38f, Random.Range(-6.4f, 0f), 0f);
                break;
        }
    }
    
    //function inherited by all objects moving towards the player, making them move
    public void ObjMovement()
    {
        transform.Translate(Vector2.left * obstacleSpeed);
        if (transform.position.x <= objOffScreenCords)
        {
            Destroy(gameObject);
        }
    }
}