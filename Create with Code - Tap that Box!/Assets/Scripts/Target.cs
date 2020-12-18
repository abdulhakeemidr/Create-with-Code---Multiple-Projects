using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explosionParticle;

    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 15;
    private float maxSpeed = 17;
    private float TorqueRange = 10;
    private float SpawnRangeX = 4;
    private float SpawnY = 6;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SpawnTargets();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.name);
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad 1"))
        {
            gameManager.GameOver();
        }
    }

    private void SpawnTargets()
    {
        targetRb.AddForce(RandomSpeed(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();

        if (gameObject.CompareTag("Mystery"))
        {
            pointValue = Random.Range(3, 6);
        }
    }

    private Vector3 RandomSpeed() { return Vector3.up * Random.Range(minSpeed, maxSpeed); }
    private float RandomTorque() { return Random.Range(-TorqueRange, TorqueRange); }
    private Vector3 RandomPosition() { return new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), -SpawnY, 0); }
}