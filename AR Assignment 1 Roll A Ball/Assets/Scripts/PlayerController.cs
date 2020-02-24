using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public float jumpHeight = 1;
    public GameState state;
    public TrailRenderer speedTrail;
    private float defaultSpeed;
    private float defaultJumpHeight;

    private Rigidbody rb;
    private bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultSpeed = speed;
        defaultJumpHeight = jumpHeight;
    }

    void Update()
    {
        // Only allow movement if game is not over
        if (!state.gameOver)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Touches on UI will not hit objects
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    RaycastHit hit;
                    Ray ray = state.current.ScreenPointToRay(touch.position);

                    if (touch.phase != TouchPhase.Ended && Physics.Raycast(ray, out hit))
                    {
                        // If ray casted on player, jump
                        if (hit.collider.gameObject.CompareTag("Player"))
                        {
                            if (canJump && touch.phase == TouchPhase.Began)
                            {
                                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
                                canJump = false;
                            }
                        }
                        // Else move
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
                else
                    return;
            }

            // Only used when debugging on PC
            if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = state.current.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        if (canJump && Input.GetMouseButtonDown(0))
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
    }

    void OnTriggerEnter(Collider other)
    {
        // Eat coins
        if (other.gameObject.CompareTag("Pick Up"))
        {
            state.UpdateScore();
            other.gameObject.SetActive(false);
        }
        // Speed up pad
        if (other.gameObject.CompareTag("Speed Up"))
        {
            speed = defaultSpeed * 2;
            jumpHeight = defaultJumpHeight * 2;
            speedTrail.enabled = true;
            StartCoroutine(SpeedDown());
        }
    }

    // Reset jump
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    private IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(5);
        speed = defaultSpeed;
        jumpHeight = defaultJumpHeight;
        speedTrail.enabled = false;
    }
}
