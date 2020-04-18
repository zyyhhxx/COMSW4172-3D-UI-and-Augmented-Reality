﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public enum Status
    {
        Empty,
        Adding,
        Tower,
        Wall,
        Action
    }

    public Status status = Status.Empty;
    public GameObject addTurret;
    public GameObject addWall;
    public GameObject translate;
    public GameObject scale;
    public GameObject rotate;
    public GameObject fire;
    public GameObject exit;
    public GameObject select;

    // Start is called before the first frame update
    void Start()
    {
        SetButtons();
    }

    // Update is called once per frame
    void Update()
    {
        SetButtons();
    }

    public void EnableFire(bool enabled)
    {
        fire.GetComponent<Button>().interactable = enabled;
    }

    void SetButtons()
    {
        switch (status)
        {
            case Status.Empty:
                addTurret.SetActive(false);
                addWall.SetActive(false);
                translate.SetActive(false);
                scale.SetActive(false);
                rotate.SetActive(false);
                fire.SetActive(false);
                exit.SetActive(false);
                select.SetActive(false);
                break;
            case Status.Adding:
                addTurret.SetActive(true);
                addWall.SetActive(true);
                translate.SetActive(false);
                scale.SetActive(false);
                rotate.SetActive(false);
                fire.SetActive(false);
                exit.SetActive(false);
                select.SetActive(true);
                break;
            case Status.Tower:
                addTurret.SetActive(false);
                addWall.SetActive(false);
                translate.SetActive(false);
                scale.SetActive(false);
                rotate.SetActive(false);
                fire.SetActive(true);
                exit.SetActive(true);
                select.SetActive(false);
                break;
            case Status.Wall:
                addTurret.SetActive(false);
                addWall.SetActive(false);
                translate.SetActive(true);
                scale.SetActive(true);
                rotate.SetActive(true);
                fire.SetActive(false);
                exit.SetActive(true);
                select.SetActive(false);
                break;
            case Status.Action:
                addTurret.SetActive(false);
                addWall.SetActive(false);
                translate.SetActive(false);
                scale.SetActive(false);
                rotate.SetActive(false);
                fire.SetActive(false);
                exit.SetActive(true);
                select.SetActive(false);
                break;
        }
    }
}
