using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DevilAttack());

    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    IEnumerator DevilAttack()
    {
        yield return new WaitForSeconds(5);
        int attackMove = Random.Range(0, 3);
        if (attackMove == 0)
        {
            //do nothing
        }
        else if (attackMove == 1)
        {
            animator.SetTrigger("Homing");

        }
        else if (attackMove == 2)
        {
            animator.SetTrigger("Teleport");
            //teleport
            //int playerX =
            //int playerY =
            //transform.position = new Vector2(playerX, playerY);
        }
        StartCoroutine(DevilAttack());

    }
}
