using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int cumulativeScore = 0;

    public void AddScore(int score)
    {
        cumulativeScore += score;
    }
}
