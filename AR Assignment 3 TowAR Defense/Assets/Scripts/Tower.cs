using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject ammoPrefab;
    public float force = 0.3f;
    public float fireRate = 10;
    public float secSinceFire;
    public float tiltUpper = 45;
    public float tiltLower = 10;

    // Start is called before the first frame update
    void Start()
    {
        secSinceFire = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        secSinceFire += Time.deltaTime;
    }

    public void Fire()
    {
        if (secSinceFire >= fireRate)
        {
            secSinceFire = 0;
            var firedAmmo = GameObject.Instantiate(ammoPrefab, firePoint.transform.position, firePoint.transform.rotation, GameObject.Find("Base Plane").transform);
            Debug.Log(firePoint.transform.forward);
            firedAmmo.GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * force, ForceMode.Impulse);
        }
    }
}
