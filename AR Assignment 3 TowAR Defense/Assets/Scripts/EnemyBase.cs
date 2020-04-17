using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int respawnDelay = 1;
    public int spawnDelay = 10;
    public GameManager gm;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(SpawnEnemy());
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
}
