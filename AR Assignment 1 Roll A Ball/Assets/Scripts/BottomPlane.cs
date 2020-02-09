using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPlane : MonoBehaviour
{
    public GameState state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.transform.position = state.spawnPoint.transform.position;
    }
}
