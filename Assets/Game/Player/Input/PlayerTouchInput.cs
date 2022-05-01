using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTouchInput : MonoBehaviour
{
    public PlayerKnife knife;

    void Start()
    {

    }

    UnityEngine.InputSystem.TouchPhase lastTouchPhase;

    void Update()
    {
        Touchscreen touchscreen = Touchscreen.current;

        if (touchscreen != null)
        {
            UnityEngine.InputSystem.TouchPhase phase = touchscreen.touches[0].ReadValue().phase;
            if (phase == UnityEngine.InputSystem.TouchPhase.Began && phase != lastTouchPhase)
            {
                knife.PerformHop();
            }
        }
        lastTouchPhase = touchscreen.touches[0].ReadValue().phase;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            knife.PerformHop();
        }
    }
}
