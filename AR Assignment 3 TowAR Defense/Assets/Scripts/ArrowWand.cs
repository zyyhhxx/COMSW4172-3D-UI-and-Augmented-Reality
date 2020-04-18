using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWand : MonoBehaviour
{
    public GameObject spawnPoint;
    public RaycastHit hit;
    public GameObject hitObject;
    public bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.up, Color.green);
        RaycastHit tempHit;
        Ray ray = new Ray(spawnPoint.transform.position, spawnPoint.transform.up);
        if(Physics.Raycast(ray, out tempHit))
        {
            if (tempHit.collider.gameObject.CompareTag("Tower") || tempHit.collider.gameObject.CompareTag("Ground"))
            {
                hasHit = true;
                hit = tempHit;
                hitObject = hit.collider.gameObject;
            }
        }
        else
        {
            hasHit = false;
            hitObject = null;
        }
    }
}
