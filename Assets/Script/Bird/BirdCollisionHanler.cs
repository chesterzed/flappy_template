using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisionHanler : MonoBehaviour
{
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     _bird.Die();
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ScoreZone scoreZone))
            _bird.AddPoint(1);
        else
            _bird.Die();
    }
}
