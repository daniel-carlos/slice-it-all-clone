using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameplayController gameplay;

    void Start()
    {
        gameplay = GameObject.FindWithTag("GameController").GetComponent<GameplayController>();    
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponentInChildren<PlayerKnife>() != null)
        {
            gameplay.OnTouchHazard();
        }
    }
}
