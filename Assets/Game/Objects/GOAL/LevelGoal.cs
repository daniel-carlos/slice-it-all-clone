using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGoal : MonoBehaviour
{
    private GameplayController gameplay;
    public float multiplier = 1;
    public TMP_Text text;

    void Start()
    {
        gameplay = GameObject.FindWithTag("GameController").GetComponent<GameplayController>();
    }

    void Update()
    {
        if (text != null)
        {
            text.text = $"{multiplier}x";
        }
    }

     private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOAL");
        PlayerKnife p = other.GetComponentInParent<PlayerKnife>();
        if (p)
        {
            gameplay.OnGoal(multiplier);
        }
    }
}
