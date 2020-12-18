using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogBoundary = 14.0f;
    public bool AllowFire = true;
    private float Timer = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if(AllowFire == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                AllowFire = false;
            }
        }
        
        // Timer that counts to 2 before allowing player to fire again
        if(AllowFire == false)
        {
            Timer += Time.deltaTime;
            //Debug.Log(Timer);
            if (Timer > 2.0f)
            {
                AllowFire = true;
                Timer = 0;
            }
        }
    }
}
