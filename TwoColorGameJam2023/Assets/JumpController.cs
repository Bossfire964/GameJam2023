using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 30f;
    private Rigidbody2D rigidBody2D;
    public int maxJumps = 2;
    public int jumpcount = 2;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.W) )&& jumpcount < maxJumps)
        {
            Debug.Log("Jumping ");
            rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpcount++;
        }

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpcount = 0;
    }
}
