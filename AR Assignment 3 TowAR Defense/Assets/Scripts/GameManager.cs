using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyBasePrefab;
    public ButtonController bc;
    public GameObject spawnPoint;
    public GameObject towerPrefab;
    public GameObject wallPrefab;
    public MeshRenderer orbWand;
    public MeshRenderer arrowWand;
    public string UIStatus = "Empty";
    public bool orbActive = false;
    public bool arrowActive = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(enemyBasePrefab, new Vector3(0.1f, 0, -0.1f), Quaternion.identity, GameObject.Find("Base Plane").transform);
        GameObject.Instantiate(enemyBasePrefab, new Vector3(0, 0, -0.1f), Quaternion.identity, GameObject.Find("Base Plane").transform);
        GameObject.Instantiate(enemyBasePrefab, new Vector3(-0.1f, 0, -0.1f), Quaternion.identity, GameObject.Find("Base Plane").transform);
    }

    // Update is called once per frame
    void Update()
    {
        orbActive = orbWand.enabled;
        arrowActive = arrowWand.enabled;
    }

    IEnumerator RespawnRoutine(Vector3 pos, Quaternion rot, int respawnDelay)
    {
        yield return new WaitForSeconds(respawnDelay);
        GameObject.Instantiate(enemyBasePrefab, pos, rot, GameObject.Find("Base Plane").transform);
    }

    public void Respawn(Vector3 pos, Quaternion rot, int respawnDelay)
    {
        StartCoroutine(RespawnRoutine(pos, rot, respawnDelay));
    }

    public void SpawnTower()
    {
        GameObject.Instantiate(towerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, GameObject.Find("Base Plane").transform);
    }

    public void SpawnWall()
    {
        GameObject.Instantiate(wallPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, GameObject.Find("Base Plane").transform);
    }
}
