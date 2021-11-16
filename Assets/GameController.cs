using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private LevelController level;
    [SerializeField] private Text scoreObject;
    [SerializeField] private float difficulty;

    private int score;

    void Start()
    {
        Reset();
    }

    void Reset()
    {
        player.Reset();
        level.Reset();

        difficulty = 0;
        SetScore(0);
    }

    private void SetScore(int newScore)
    {
        score = newScore;

        scoreObject.text = score.ToString();
    }

    public void PlayerSucceed() {
        SetScore(score += 100);
    }

    public void PlayerFailed() {
        Reset();
    }
}
