using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject ammoPrefab;
    public GameObject turret;
    public float force = 0.3f;
    public float fireRate = 10;
    public float secSinceFire;
    public float tiltUpper = -10;
    public float tiltLower = -45;

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

    public void RotateTurretArrow(Vector3 direction)
    {
        var newAngle = new Vector3(direction.x, direction.y, 0);
        Debug.Log(newAngle);
        if (newAngle.x > tiltUpper)
            newAngle.x = tiltUpper;
        if (newAngle.x < tiltLower)
            newAngle.x = tiltLower;
        turret.transform.eulerAngles = newAngle;
    }

    public void RotateTurretOrb(Transform target)
    {
        turret.transform.LookAt(target);
        var angle = turret.transform.eulerAngles;
        var newAngle = new Vector3(angle.x, angle.y, 0);
        Debug.Log(newAngle);
        if (newAngle.x > tiltUpper)
            newAngle.x = tiltUpper;
        if (newAngle.x < tiltLower)
            newAngle.x = tiltLower;
        turret.transform.eulerAngles = newAngle;
    }
}
