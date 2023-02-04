using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnZ : MonoBehaviour
{
    private float z;
    void Start()
    {
        z = transform.position.z;
    }

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        transform.position = new Vector3(x, y, z);
    }
}
