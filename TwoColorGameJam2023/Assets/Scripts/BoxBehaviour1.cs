using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour1 : MonoBehaviour
{
    public float flapForce = 80;
    public float health = 100;
    public int numCoins = 0;
    public AudioClip bounceSound;
    public float x;
    public float y;
    public float z;
      public float speed = 5f;
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float shootForce = 10f;
    public int maxballs = 4;
    GameObject temp;
    public float deadzone = 100;
    private Rigidbody2D rigidbody2D;
    public float projectileSpeed = 10.0f;
    public int timer = 0;
    public float distanceThreshold = 10.0f;
    private void Start()
    {
        

        rigidbody2D = GetComponent<Rigidbody2D>();
        //temp = Instantiate(projectilePrefab);
    }

    private void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);
        //timer++;
       // Debug.Log(timer);
       

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10; // The distance between the camera and object
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
            GameObject projectile = Instantiate(projectilePrefab, transform.position, rot);
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
            rigidbody.velocity = (mousePos.normalized * projectileSpeed);

            float distance = Vector3.Distance(projectile.transform.position, transform.position);
            if (mousePos.x > distanceThreshold)
            {
                //Destroy(projectilePrefab);
            }

        }
        
    }



    //  }

}
//This script uses a Rigidbody2D component to move the box left or right in response to horizontal input, and to jump in response to a jump button press. The jumpForce variable determines the strength of the jump, and the maxJumps variable sets the number of jumps allowed before touching the ground again. The jumpCount variable keeps track of the number of jumps made, and is reset to zero when the box collides with an object with a Collider2D component, which is detected using the OnCollisionEnter2D method.



