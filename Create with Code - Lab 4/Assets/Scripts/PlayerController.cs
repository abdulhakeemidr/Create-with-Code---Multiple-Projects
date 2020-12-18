using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float zBoundary = 6.0f;
    private Rigidbody playerRb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        ImposePlayerBoundary();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with Enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalInput, 0, verticalInput);

        //playerRb.AddForce(movement * speed);

        playerRb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }

    void ImposePlayerBoundary()
    {
        if (transform.position.z > zBoundary)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y, zBoundary);
        }
        else if (transform.position.z < -zBoundary)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y, -zBoundary);
        }
    }    
}
