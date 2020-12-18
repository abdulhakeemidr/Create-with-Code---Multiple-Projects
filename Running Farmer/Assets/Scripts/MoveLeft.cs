using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Speed = 30f;
    private PlayerController PlayerControlScript;
    public float leftBoundary = -10f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControlScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // As long as the game is not over, the obstacles and scene keep moving left
        if(PlayerControlScript.GameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * Speed);

        if(transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
