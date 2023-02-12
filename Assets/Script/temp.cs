using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class temp : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
    }

    private void Start()
    {
        // start
    }

    private void OnMove(Vector2 direction)
    {
        rb.velocity = new Vector3(
            direction.x, 
            rb.velocity.y, 
            direction.y
            );
        
    }
}