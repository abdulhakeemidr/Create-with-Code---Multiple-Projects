using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject Powerup;

    private float startDelay = 0.5f;
    private float spawnIntervalEnemy = 3f;
    private float spawnIntervalPowerup = 7f;
    private float zSpawnPosition = 12f;
    private float xSpawnRange = 7f;
    private float ySpawn = 0.6f;
    private float zPowerupRange = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnPowerup();
        InvokeRepeating("SpawnEnemy", startDelay, spawnIntervalEnemy);
        InvokeRepeating("SpawnPowerup", startDelay, spawnIntervalPowerup);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int randomPrefab = Random.Range(0, enemies.Length);
        float RandomPosX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 randomPosition = new Vector3(RandomPosX, ySpawn, zSpawnPosition);
        Instantiate(enemies[randomPrefab], randomPosition, 
            enemies[randomPrefab].transform.rotation * Quaternion.Euler(0, 180, 0));
    }

    void SpawnPowerup()
    {
        float RandomPosX = Random.Range(-zSpawnPosition, zSpawnPosition);
        float RandomPosZ = Random.Range(-zPowerupRange, zPowerupRange);
        Vector3 randomPosition = new Vector3(RandomPosX, ySpawn, RandomPosZ);

        Instantiate(Powerup, randomPosition, Powerup.transform.rotation);
    }
}
