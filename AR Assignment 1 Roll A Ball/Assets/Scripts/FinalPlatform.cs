using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is used by the final platform that ends the game

public class FinalPlatform : MonoBehaviour
{
    public GameState state;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state.EndGame();
        }
    }
}
