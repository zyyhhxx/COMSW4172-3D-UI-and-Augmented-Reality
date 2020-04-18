using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbWand : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tower")
            hit = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        hit = null;
    }
}
