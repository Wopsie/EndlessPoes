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

    // Update is called once per frame
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

    void Spawner()
    {
        //spawns = Spawns.Enemy;
        spawns = (Spawns)Random.Range(0, 5);
        rarity = (Spawns)Random.Range(1, 5);
        platSpawn = (Spawns)Random.Range(1, 4);

        var clone = (GameObject)Instantiate(map[spawns], transform.position, Quaternion.identity);

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
            Debug.Log("THOU CAN SPAWN THE PLATFORM " + platformSpawn);
            platformSpawn = 0;
        }else if(clone.tag == "GroundFloor" && platformSpawn <= 4)
        {
            Debug.Log("DONT SPAWN THAT SHIT " + platformSpawn);
            Destroy(clone);
            Instantiate(map[platSpawn], transform.position, Quaternion.identity);
        }
        
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

    public void ObjMovement()
    {
        transform.Translate(Vector2.left * obstacleSpeed);
        if (transform.position.x <= objOffScreenCords)
        {
            Destroy(gameObject);
        }
    }
}