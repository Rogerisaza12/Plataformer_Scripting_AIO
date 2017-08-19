using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    public Transform[] spawnPoints;
    public float spawnTime = 2f;
    public GameObject rocas;

	void Start()
    {
        InvokeRepeating("SpawnRocks", spawnTime, spawnTime);
    }
	void Update ()
    {
	    	
	}
    void SpawnRocks()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(rocas, spawnPoints[spawnIndex].position,spawnPoints[spawnIndex].rotation);
    }
}
