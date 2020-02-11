using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustableObject : MonoBehaviour
{
    public GameState state;
    public Rotation rotation;
    public Resizing resizing;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        rotation = gameObject.GetComponent<Rotation>();
        resizing = gameObject.GetComponent<Resizing>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
            ActivateSlider(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ActivateSlider(other.gameObject);
    }

    private void ActivateSlider(GameObject go)
    {
        state.currentAdjustable = this;
        float ratio = 0.5f;
        if (!(rotation is null))
        {
            ratio = (rotation.speed - rotation.minSpeed) / (rotation.maxSpeed - rotation.minSpeed);
        }
        else if (!(resizing is null))
        {
            ratio = (resizing.rate - resizing.lowerLimit) / (resizing.upperLimit - resizing.lowerLimit);
        }
        slider.value = ratio;
        slider.gameObject.SetActive(true);
        StartCoroutine(DeactivateSlider());
    }

    IEnumerator DeactivateSlider()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        slider.gameObject.SetActive(false);
    }

    public void SliderChange(float value)
    {
        Debug.Log(value);
        if (!(rotation is null))
        {
            rotation.speed = rotation.minSpeed + value * (rotation.maxSpeed - rotation.minSpeed);
            Debug.Log(rotation.speed);
            foreach (var childrenRotation in GetComponentsInChildren<Rotation>())
            {
                if(childrenRotation.gameObject.GetInstanceID() != gameObject.GetInstanceID())
                    childrenRotation.speed = -rotation.speed;
            }
        }
        else if (!(resizing is null))
        {
            resizing.rate = resizing.lowerLimit + value * (resizing.upperLimit - resizing.lowerLimit);
        }
    }
}
