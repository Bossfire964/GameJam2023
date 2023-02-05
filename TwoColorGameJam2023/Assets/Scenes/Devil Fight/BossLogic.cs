using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public Animator animator;
    public GameObject caneObject;
    public float caneSpeed;
    bool canRun = true;
    public float movementSpeed = 5;
    public bool secondStage = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DevilAttack());

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x<8 || transform.position.x>26)
        {
            movementSpeed *= -1;
        }
        
        transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
        if (GetComponent<BossHealth>().health < 100)
        {
            secondStage = true;
            GetComponent<BossHealth>().noHurt = true;
            animator.SetTrigger("Transition");
            StartCoroutine(animationWait());
        }

    }

    IEnumerator animationWait()
    {
        yield return new WaitForSeconds(4);
        GetComponent<BossHealth>().noHurt = false;

    }

    IEnumerator secondStageAttack()
    {
        yield return new WaitForSeconds(1.5f);
        int attackMove = Random.Range(0, 3);
        //attackMove = 1;
        if (attackMove == 0)
        {
            animator.SetTrigger("Homing");
            GameObject newCane = Instantiate(caneObject, gameObject.GetComponentInChildren<Transform>().position - new Vector3(20, 10, 0), Quaternion.identity);
            newCane.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime * caneSpeed, ForceMode2D.Impulse);
            newCane.GetComponent<Rigidbody2D>().AddForce((Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right) * Time.deltaTime * caneSpeed, ForceMode2D.Impulse);
            newCane.GetComponent<Rigidbody2D>().AddTorque(100f);
        }
        else if (attackMove == 1)
        {
            animator.SetTrigger("Homing");
            GameObject newCane = Instantiate(caneObject, gameObject.GetComponentInChildren<Transform>().position - new Vector3(20, 10, 0), Quaternion.identity);
            newCane.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime * caneSpeed, ForceMode2D.Impulse);
            newCane.GetComponent<Rigidbody2D>().AddForce((Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right) * Time.deltaTime * caneSpeed, ForceMode2D.Impulse);
            newCane.GetComponent<Rigidbody2D>().AddTorque(100f);
        }
        else if (attackMove == 2)
        {
            animator.SetTrigger("Teleport");
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Char").GetComponent<Transform>().position;
            yield return new WaitForSeconds(1);
            gameObject.transform.position = new Vector3(playerPos.x + 25, playerPos.y + 15, 0);
            //teleport
            //int playerX =
            //int playerY =
            //transform.position = new Vector2(playerX, playerY);
        }
        if (!secondStage)
        {
            StartCoroutine(DevilAttack());

        }

    }


    IEnumerator DevilAttack()
    {
        yield return new WaitForSeconds(3);
        int attackMove = Random.Range(0, 3);
        //attackMove = 1;
        if (attackMove == 0)
        {
            //do nothing
        }
        else if (attackMove == 1)
        {
            animator.SetTrigger("Homing");
            GameObject newCane = Instantiate(caneObject, gameObject.GetComponentInChildren<Transform>().position - new Vector3(20,10,0), Quaternion.identity);
            newCane.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime * caneSpeed, ForceMode2D.Impulse);
            newCane.GetComponent<Rigidbody2D>().AddForce((Random.Range(0,2)==0 ? Vector2.left:Vector2.right) * Time.deltaTime * caneSpeed, ForceMode2D.Impulse);
            newCane.GetComponent<Rigidbody2D>().AddTorque(100f);
        }
        else if (attackMove == 2)
        {
            animator.SetTrigger("Teleport");
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Char").GetComponent<Transform>().position;
            yield return new WaitForSeconds(1);
            gameObject.transform.position = new Vector3(playerPos.x + 25, playerPos.y + 15, 0);
            //teleport
            //int playerX =
            //int playerY =
            //transform.position = new Vector2(playerX, playerY);
        }
        if (!secondStage)
        {
            StartCoroutine(DevilAttack());

        }

    }
}
