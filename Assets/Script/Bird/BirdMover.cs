using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;

    [SerializeField] private float minRotationZ;
    [SerializeField] private float maxRotationZ;
    [SerializeField] private float rotationSpeed;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        _minRotation = Quaternion.Euler(0, 0, minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, maxRotationZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(speed, jumpForce);
            transform.rotation = _maxRotation;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = startPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }
}
