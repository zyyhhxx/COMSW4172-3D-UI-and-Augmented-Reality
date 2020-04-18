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

    public enum Action
    {
        Translate,
        Rotate,
        Scale
    }

    public GameObject enemyBasePrefab;
    public ButtonController bc;
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
    public Action currentAction;

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

        if(selectedType == Selectable.Tower && bc.status == ButtonController.Status.Tower)
        {
            // Set if the fire button can be used
            var tower = selected.GetComponent<Tower>();
            bc.EnableFire(tower.secSinceFire >= tower.fireRate);

            // Rotate the turret
            if (orbActive)
                tower.RotateTurretOrb(ow.spawnPoint.transform);
            else if(arrowActive)
                tower.RotateTurretArrow(aw.gameObject.transform.eulerAngles);
        }
        else if (bc.status == ButtonController.Status.Action)
        {
            var wall = selected.GetComponent<Wall>();

            if (currentAction == Action.Rotate)
            {
                if(orbActive)
                    wall.RotateOrb(ow.spawnPoint.transform);
            }
            else if (currentAction == Action.Translate)
            {

            }
            else if (currentAction == Action.Scale)
            {

            }
        }
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
        if (orbActive)
        {
            if (ow.hit)
            {
                selected = ow.hit;
                if (selected.GetComponent<Tower>())
                {
                    selectedType = Selectable.Tower;
                    bc.status = ButtonController.Status.Tower;
                }
                else
                {
                    selectedType = Selectable.Wall;
                    bc.status = ButtonController.Status.Wall;
                }
            }
        }
    }

    public void Exit()
    {
        if(bc.status == ButtonController.Status.Action)
            bc.status = ButtonController.Status.Wall;
        else if(bc.status == ButtonController.Status.Wall || bc.status == ButtonController.Status.Tower)
        {
            selected = null;
            bc.status = ButtonController.Status.Adding;
        }
            
    }

    public void Fire()
    {
        selected.GetComponent<Tower>().Fire();
    }

    public void Translate()
    {
        currentAction = Action.Translate;
        bc.status = ButtonController.Status.Action;
    }

    public void Rotate()
    {
        currentAction = Action.Rotate;
        bc.status = ButtonController.Status.Action;
    }

    public void Scale()
    {
        currentAction = Action.Scale;
        bc.status = ButtonController.Status.Action;
    }
}
