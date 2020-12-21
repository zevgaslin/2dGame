using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Text text;
    public GameObject hitEffect;
    float invulnurabeleTime;
    public float startInvTime;
    public int coin;
    public Text coinText;
    float coinTime;

    // Start is called before the first frame update
    void Start()
    {
        text.text = health.ToString();
        invulnurabeleTime = 0f;
        coin = 0;
        coinText.text = coin.ToString();
        coinTime = 1f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 && invulnurabeleTime <= 0f)
        {
            health -= other.gameObject.GetComponent<EnemyHealth>().Damage;
            text.text = health.ToString();
            Instantiate(hitEffect, this.transform);
            invulnurabeleTime = startInvTime;
        }
        if(other.gameObject.tag == "Coin" && coinTime >= 1f)
        {
            coinTime = 0f;
            Destroy(other.gameObject);
            coin += 1;
            coinText.text = coin.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
     if(other.gameObject.layer == 7)
        {
            health = 0f;
            invulnurabeleTime = startInvTime;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        coinTime += 1;
       if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       if(invulnurabeleTime > 0)
        {
            invulnurabeleTime -= Time.deltaTime;
        }
    }
}
