using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to control platorm-related behaviors

public class Platform : MonoBehaviour
{
    public GameState state;
    public GameObject spawnPoint;

    // When the player hits the platoform, set the respawn point
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state.spawnPoint = spawnPoint;
        }
    }
}
