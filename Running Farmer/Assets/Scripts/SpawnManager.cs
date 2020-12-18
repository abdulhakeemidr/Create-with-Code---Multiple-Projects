using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    private Vector3 SpawnPosition = new Vector3(35, 0, 0);
    public float StartTime = 2f;
    public float RepeatTime = 2f;
    private PlayerController playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", StartTime, RepeatTime);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        // as long as the game is not over, the obstacles keep spawning (instantiating)
        if(playerControlScript.GameOver == false)
            Instantiate(ObstaclePrefab, SpawnPosition, ObstaclePrefab.transform.rotation);
    }
}
