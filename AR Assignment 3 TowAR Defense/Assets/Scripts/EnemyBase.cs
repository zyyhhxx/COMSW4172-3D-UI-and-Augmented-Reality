using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int respawnDelay = 5;
    public int spawnDelay = 20;
    public int fireRate = 10;
    public float force = 0.3f;
    public GameManager gm;
    public GameObject enemy;
    public GameObject ammo;
    public GameObject firePoint;
    public GameObject[] targets;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(SpawnEnemy());
        StartCoroutine(FindTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        gm.Respawn(this.gameObject.transform.position, this.gameObject.transform.rotation, respawnDelay);
    }

    IEnumerator SpawnEnemy()
    {
        for(;;)
        {
            GameObject.Instantiate(enemy, this.gameObject.transform.position, this.gameObject.transform.rotation, GameObject.Find("Base Plane").transform);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator FindTarget()
    {
        for (;;)
        {
            // Get the target
            targets = GameObject.FindGameObjectsWithTag("Tower");
            if (targets.Length > 0)
            {
                int index = Random.Range(0, targets.Length);
                var target = targets[index];

                //Fire at the target
                var heading = target.transform.position - this.gameObject.transform.position;
                var distance = heading.magnitude;
                var direction = heading / distance;
                var fireDirection = new Vector3(direction.x, 1, direction.z);
                Debug.Log((heading, distance, fireDirection));
                var firedAmmo = GameObject.Instantiate(ammo, firePoint.transform.position, firePoint.transform.rotation, GameObject.Find("Base Plane").transform);
                firedAmmo.GetComponent<Rigidbody>().AddForce(fireDirection * Random.Range(force * 0.5f, force), ForceMode.Impulse);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
}
