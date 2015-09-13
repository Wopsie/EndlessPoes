using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public enum Spawns
    {
        PowerUp,
        ExtraPoints,
        Crate,
        Platform,
        Enemy,
        Bird
    }

    private Spawns spawns;
    public float obstacleSpeed = 0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawner()
    {
        spawns = (Spawns)Random.Range(0, 7);
        Transform ExtraPoints;
        switch (spawns)
        {
            case Spawns.PowerUp:
                // spawn PowerUp

                break;
            case Spawns.ExtraPoints:
                // spawn ExtraPoints

                break;
            case Spawns.Crate:
                // spawn Crate

                break;
            case Spawns.Platform:
                // spawn Platform

                break;
            case Spawns.Enemy:
                // spawn Enemy

                break;
            case Spawns.Bird:
                // spawn Bird

                break;
        }
        //spawning
    }
}
