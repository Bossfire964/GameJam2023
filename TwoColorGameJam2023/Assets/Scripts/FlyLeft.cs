using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLeft : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if(transform.position.x < 12)
        {
            Destroy(gameObject);
        }
    }
}
