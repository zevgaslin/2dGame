using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public float speed;
    public float startSpeed;
    public float startDazedTime;
    public float dazedTime;
    GameObject target;
    Rigidbody2D rb;
    public float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0f)
        {
            speed = startSpeed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }


        Vector2 direction = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);

        float angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;

        rb.rotation = angle;

        if(Vector2.Distance(this.gameObject.transform.position, target.gameObject.transform.position) < distance)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
