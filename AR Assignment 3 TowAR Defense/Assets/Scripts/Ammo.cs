using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int damage = 30;
    public bool damageTower = true;
    public bool damageEnemy = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        var target = collision.gameObject;
        if ((target.tag == "Tower" && damageTower) || (target.tag == "Enemy" && damageEnemy))
        {
            target.GetComponent<Health>().health -= damage;
            Destroy(this.gameObject);
        }
        else if (target.tag == "Ground")
            Destroy(this.gameObject);
    }
}
