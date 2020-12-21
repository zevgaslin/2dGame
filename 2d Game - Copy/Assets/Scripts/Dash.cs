using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dash
        float h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (h > 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 5);
                Debug.DrawRay(transform.position, Vector2.right, Color.white, 500);
                if(hit.collider.tag == "wall")
                {
                    return;
                }
                else
                {
                    transform.Translate(Vector2.right * 5);
                }
            }
            if (h < 0)
            {
                transform.Translate(Vector2.left * 5);

            }
        }

        //slowmode
        if (Input.GetKeyDown("q"))
        {
            Time.timeScale = 0.5f;
        }
        if (Input.GetKeyUp("q"))
        {
            Time.timeScale = 1f;
        }

    }

    
}
