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

    public void UIStatus(bool arrow, bool orb)
    {
        // When wands are both present or missing, ban all actions
        if((arrow && orb) || (!arrow && !orb))
        {
            status = Status.Empty;
        }
        else
        {
            switch (status)
            {
                case Status.Empty:
                    if (arrow ^ orb)
                    {
                        status = Status.Adding;
                    }
                    break;
            }
        }
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
                break;
            case Status.Adding:
                addTurret.SetActive(true);
                addWall.SetActive(true);
                translate.SetActive(false);
                scale.SetActive(false);
                rotate.SetActive(false);
                fire.SetActive(false);
                exit.SetActive(false);
                break;
        }
    }
}
