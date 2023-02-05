using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Char"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(5);
        } else if (collision.gameObject.CompareTag("Platform"))
        {
            Rigidbody2D rg = gameObject.GetComponent<Rigidbody2D>();
            rg.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }
}
