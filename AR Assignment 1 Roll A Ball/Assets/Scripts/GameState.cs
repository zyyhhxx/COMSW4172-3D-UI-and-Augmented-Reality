﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
