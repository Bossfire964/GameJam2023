using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health = 1;
    public float bulletDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            gameObject.GetComponentInChildren<Animator>().Play("Dino_Death");
        }
    }

    public void damageBoss()
    {
        health -= bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Char"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(20);
        }
    }
}
