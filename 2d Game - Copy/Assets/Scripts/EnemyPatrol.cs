using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float startSpeed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    public float startDazedTime;
    public float dazedTime;

    private void Update()
    {
        if(dazedTime <= 0f)
        {
            speed = startSpeed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }


}
