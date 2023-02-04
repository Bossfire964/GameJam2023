using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public int zed = 0;
    public int axisY = 0;
    public GameObject target;
    void Update()
    {
        transform.position = new Vector3 (target.transform.position.x, target.transform.position.y + axisY, target.transform.position.z - zed);
    }
}
