using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class GameplayController : MonoBehaviour
{
    public PlayerKnife player;

    private bool gameplayStarted = false;
    private bool playerDead = false;
    private bool levelFinished = false;

    [Header("UI")]
    public GameObject gameoverPanel;

    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    void Update()
    {

    }

    internal void OnGoal(float multiplier)
    {
        player.GetComponent<PlayerScore>().cumulativeScore = Mathf.FloorToInt(player.GetComponent<PlayerScore>().cumulativeScore * multiplier);
        player.Active = false;
        player.Stuck();
        levelFinished = true;
    }

    public void OnPlayerInteraction()
    {
        if (levelFinished)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!playerDead && !gameplayStarted)
        {
            player.Active = true;
            gameplayStarted = true;
        }
    }

    public void OnTouchHazard()
    {
        player.Active = false;
        playerDead = true;
        gameoverPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

