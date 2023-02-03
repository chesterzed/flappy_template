using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdTracker : MonoBehaviour
{
    [FormerlySerializedAs("_bird")] [SerializeField] private Bird bird;
    [FormerlySerializedAs("_offset")] [SerializeField] private float offset;

    void Update()
    {
        transform.position = new Vector3(
            bird.transform.position.x + offset,
            transform.position.y,
            transform.position.z);
    }
}
