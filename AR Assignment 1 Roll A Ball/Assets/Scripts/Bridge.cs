using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to controll the bridge blocks

public class Bridge : MonoBehaviour
{
    public Rigidbody rb;
    public float delay = 1;

    // If touched by the player, start to count for falling
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
            StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
