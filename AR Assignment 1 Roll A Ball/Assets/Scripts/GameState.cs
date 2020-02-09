using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    public Text timeText;
    public Camera main;
    public Camera map;
    public Camera current;

    public Button[] buttons;
    private float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        timeText.text = "Time: 0";
        current = main;
        map.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        timeText.text = "Time: " + Math.Round(timeElapsed, 1).ToString();
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SwitchCamera()
    {
        if(current == main)
        {
            current = map;
            main.gameObject.SetActive(false);
            map.gameObject.SetActive(true);
            foreach(var button in buttons)
            {
                button.gameObject.SetActive(false);
            }
        }
        else
        {
            current = main;
            map.gameObject.SetActive(false);
            main.gameObject.SetActive(true);
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true);
            }
        }
    }
}
