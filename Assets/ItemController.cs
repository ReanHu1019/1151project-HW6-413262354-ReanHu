using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json.Nodes;
using System;


public class ItemController : MonoBehaviour
{
    public float dropSpeed = -0.03f;

    void Update()
    {
        transform.Translate(0, this.dropSpeed, 0);
        if(transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
    }
}
