﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyBasePrefab;

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
}