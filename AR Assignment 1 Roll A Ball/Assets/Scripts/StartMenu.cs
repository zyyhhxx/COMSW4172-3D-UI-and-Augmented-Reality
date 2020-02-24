using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is the script to handle the start menu

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
