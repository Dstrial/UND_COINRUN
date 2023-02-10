using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Score score = GameManager.Inst.Player.GetComponent<Score>();
        score.onScoreChange += Refresh;
    }

    private void Refresh(int score)
    {
        scoreText.text = $"Score : {score:##0}";
    }

}
