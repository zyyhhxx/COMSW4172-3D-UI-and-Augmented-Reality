﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public float jumpHeight = 1;
    public GameState state;

    private Rigidbody rb;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            RaycastHit hit;
            Ray ray = state.current.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Player") && touch.phase == TouchPhase.Began)
                {
                    if (canJump)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
                        canJump = false;
                    }
                }
                else
                {
                    Vector3 pointHit = hit.point;
                    var heading = pointHit - transform.position;
                    var direction = heading / heading.magnitude;

                    Vector3 movement = new Vector3(direction.x * speed, 0, direction.z * speed);
                    rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = state.current.ScreenPointToRay(Input.mousePosition);

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Player") && Input.GetMouseButtonDown(0))
                {
                    if (canJump)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
                        canJump = false;
                    }
                }
                else
                {
                    Vector3 pointHit = hit.point;
                    var heading = pointHit - transform.position;
                    var direction = heading / heading.magnitude;

                    Vector3 movement = new Vector3(direction.x * speed, 0, direction.z * speed);
                    rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            state.score += 1;
            state.UpdateScore();
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
