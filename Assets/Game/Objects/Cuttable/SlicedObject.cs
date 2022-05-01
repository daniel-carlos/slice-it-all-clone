using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedObject : MonoBehaviour
{
    public float throwSpeed = 1f;
    public float throwAngularSpeed = 1f;

    public Rigidbody rightHalf;
    public Rigidbody leftHalf;

    public float lifetime = 5f;

    void Start()
    {
        rightHalf.velocity = Vector3.back * throwSpeed;
        rightHalf.angularVelocity = Random.insideUnitSphere * throwAngularSpeed;
        leftHalf.velocity = Vector3.forward * throwSpeed;
        leftHalf.angularVelocity = Random.insideUnitSphere * throwAngularSpeed;

        Destroy(gameObject, lifetime);
    }

}
