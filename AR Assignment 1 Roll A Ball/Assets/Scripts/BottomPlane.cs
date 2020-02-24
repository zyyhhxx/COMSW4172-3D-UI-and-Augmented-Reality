using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPlane : MonoBehaviour
{
    public GameState state;

    // When the player hits the bottom plane, respawn the player
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.transform.position = state.spawnPoint.transform.position;
    }
}
