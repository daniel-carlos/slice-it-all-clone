using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform knife_t;
    Vector3 offset;
    
    void Start()
    {
        offset = knife_t.position - transform.position;
    }

    void Update()
    {
        transform.position = knife_t.position - offset;
    }
}
