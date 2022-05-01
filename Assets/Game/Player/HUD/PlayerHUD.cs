using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public PlayerScore playerScore;
    public TMP_Text scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = $"Coins: {playerScore.cumulativeScore}";
    }
}
