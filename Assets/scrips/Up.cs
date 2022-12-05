using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.position = transform.position + new Vector3(0f, speed * Time.deltaTime, 0f);
    }
}

