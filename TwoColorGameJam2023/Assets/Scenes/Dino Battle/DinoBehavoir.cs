using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBehavoir : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rg;
    public float jumpHeight = 20;
    public float horizontalMovement = 2;
    public GameObject player;
    public GameObject spitProjectile;
    public GameObject dinoMini;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rg = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(dinoAttacks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dinoAttacks()
    {
        yield return new WaitForSeconds(0.5f);
        int gameAttack = Random.Range(0, 5);
        gameAttack = 3;
        if (gameAttack < 2)
        {
            animator.SetTrigger("Jump");
            rg.AddForce(Vector2.up * Time.deltaTime * jumpHeight);
            if (player.transform.position.x < gameObject.GetComponentInChildren<Transform>().position.x)
            {
                rg.AddForce(Vector2.left * Time.deltaTime * horizontalMovement, ForceMode2D.Impulse);

            }
            else
            {
                rg.AddForce(Vector2.right * Time.deltaTime * horizontalMovement, ForceMode2D.Impulse);

            }
            yield return new WaitForSeconds(2);
        } else if (gameAttack == 2)
        {
            animator.SetTrigger("Spit");
            Vector3 playerPos = Camera.main.ScreenToWorldPoint(player.transform.position);
            Vector2 direction = (Vector2)((playerPos - transform.position));
            direction.Normalize();
            GameObject spit = Instantiate(spitProjectile, gameObject.GetComponentInChildren<Transform>().position, Quaternion.identity);
            spit.GetComponent<Rigidbody2D>().velocity = direction * 10;
            yield return new WaitForSeconds(3);
        } else if (gameAttack == 3)
        {
            animator.SetTrigger("Charge");
            yield return new WaitForSeconds(0.5f);
            if (player.transform.position.x < gameObject.GetComponentInChildren<Transform>().position.x) {
                
                rg.AddForce(Vector2.left * Time.deltaTime * 500, ForceMode2D.Impulse);

            } else
            {
                rg.AddForce(Vector2.right * Time.deltaTime * 500, ForceMode2D.Impulse);

            }

            yield return new WaitForSeconds(5);
        } else
        {
            animator.SetTrigger("Army");
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i<Random.Range(2,12); i++)
            {
                yield return new WaitForSeconds(0.5f);
                Instantiate(dinoMini);
            }
            animator.SetTrigger("Idle");
        }
       
        StartCoroutine(dinoAttacks());
    }
}
