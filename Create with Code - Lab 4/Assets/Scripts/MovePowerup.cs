using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePowerup : MonoBehaviour
{
    private float rotationSpeed = 30f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if(transform.position.y < 1)
        {
            rb.AddForce(-1 * Physics.gravity);
        }
        else if (transform.position.y > 2)
        {
            rb.AddForce(Physics.gravity);
        }
    }
}
