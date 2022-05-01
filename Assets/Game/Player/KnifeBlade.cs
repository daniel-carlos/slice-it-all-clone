using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBlade : MonoBehaviour
{
    public PlayerKnife knife;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Blade colliding");
    }
}
