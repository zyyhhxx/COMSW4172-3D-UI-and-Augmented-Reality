using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Selectable
    {
        Tower,
        Wall
    }

    public GameObject enemyBasePrefab;
    public ButtonController bc;
    public GameObject spawnPoint;
    public GameObject towerPrefab;
    public GameObject wallPrefab;
    public MeshRenderer orbWand;
    public MeshRenderer arrowWand;
    public OrbWand ow;
    public ArrowWand aw;
    public bool orbActive = false;
    public bool arrowActive = false;
    public GameObject selected;
    public Selectable selectedType;

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
        bc.UIStatus(arrowActive, orbActive);
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
        if (orbActive)
        {
            var spawnTransform = ow.spawnPoint.transform;
            GameObject.Instantiate(towerPrefab, spawnTransform.position, Quaternion.identity, GameObject.Find("Base Plane").transform);
        }
            
    }

    public void SpawnWall()
    {
        if (orbActive)
        {
            var spawnTransform = ow.spawnPoint.transform;
            GameObject.Instantiate(wallPrefab, spawnTransform.position, Quaternion.identity, GameObject.Find("Base Plane").transform);
        }
    }

    public void Select()
    {

    }
}
