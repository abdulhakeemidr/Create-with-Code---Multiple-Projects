using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public float BallBoundary = -13.0f;

    public float spawnLimitXLeft = -20;
    public float spawnLimitXRight = 7;
    public float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        int newBall = Random.Range(0, 2);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[newBall], spawnPos, ballPrefabs[newBall].transform.rotation);
        //spawnInterval = Random.Range(1.0f, 10f);
        //Debug.Log(spawnInterval);
    }

}
