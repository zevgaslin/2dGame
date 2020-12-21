using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttack;
    public float StartTimeBetweenAttack;
    public float range;
    public Transform swordPos;
    public LayerMask enemy;
    public int damage;
    public GameObject attackEffet;

    // Update is called once per frame
    void Update()
    {
         if(timeBetweenAttack <= 0f)
         {
            if (Input.GetButton("Fire1"))
            {                   
                Instantiate(attackEffet, swordPos.transform.position, swordPos.transform.rotation);
                timeBetweenAttack = StartTimeBetweenAttack; 
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(swordPos.position, range, enemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                }

            }


        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }

       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(swordPos.position, range);
    }
}
