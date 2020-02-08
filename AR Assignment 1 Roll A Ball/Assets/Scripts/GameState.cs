using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Camera main;
    public Camera map;

    public Camera current;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        current = main;
        map.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void SwitchCamera()
    {
        if(current == main)
        {
            current = map;
            main.gameObject.SetActive(false);
            map.gameObject.SetActive(true);
        }
        else
        {
            current = main;
            map.gameObject.SetActive(false);
            main.gameObject.SetActive(true);
        }
    }
}
