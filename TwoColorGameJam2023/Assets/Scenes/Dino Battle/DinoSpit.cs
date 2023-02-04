using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpit : MonoBehaviour
{
    GameObject player;
    public float bulletspeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Char");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Camera.main.ScreenToWorldPoint(player.transform.position);
        Vector2 direction = (Vector2)((playerPos - transform.position));
        direction.Normalize();
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Char"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(10);
        }
    }
}
