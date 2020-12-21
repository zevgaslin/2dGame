using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject hitEffect;
    public float Damage;
    public GameObject coin;

    public void TakeDamage(int damage)
    {
        this.gameObject.GetComponent<EnemyPatrol>().dazedTime = this.gameObject.GetComponent<EnemyPatrol>().startDazedTime; 
        health -= damage;
        Instantiate(hitEffect, this.transform);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 7)
        {
            health = 0f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Instantiate(hitEffect, this.transform);
            Instantiate(coin, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
