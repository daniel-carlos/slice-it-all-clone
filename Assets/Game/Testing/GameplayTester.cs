using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameplayTester : MonoBehaviour
{
    [Header("Time Control")]
    [Range(0f, 1f)]
    public float timeScale = 1f;

    void Update()
    {
        Time.timeScale = timeScale;
    }

    private void Start() {
        InvokeRepeating("TakeScreenshot", 1f,1f);
    }

    void TakeScreenshot()
    {
        Guid g = Guid.NewGuid();
        ScreenCapture.CaptureScreenshot($"screenshots/{g}.png");
    }
}
