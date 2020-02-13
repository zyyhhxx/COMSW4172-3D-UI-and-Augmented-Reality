using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Rigidbody rb;
    public float delay = 1;

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
