using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;
    public PhysicsMaterial2D pm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //slowmode
        if (Input.GetKeyDown("q"))
        {
            Time.timeScale = 0.5f;
        }
        if (Input.GetKeyUp("q"))
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown("e"))
        {
            pm.bounciness = 1.1f;
        }
        if (Input.GetKeyUp("e"))
        {
            pm.bounciness = 0;
        }

    }

    
}
