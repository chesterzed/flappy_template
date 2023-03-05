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
        
        rb.AddForce(Vector3.up, ForceMode.VelocityChange);
    }

    private void OnEnable()
    {
        //end
    }

    private void Start()
    {
        
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