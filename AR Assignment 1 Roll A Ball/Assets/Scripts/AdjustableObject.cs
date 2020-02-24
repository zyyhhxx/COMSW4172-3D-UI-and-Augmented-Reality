using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class handles objects that can have their speed adjusted by a slider

public class AdjustableObject : MonoBehaviour
{
    public GameState state;
    public Rotation rotation;
    public Resizing resizing;
    public Slider slider;

    void Start()
    {
        // Get the reference to the script controlling the speed
        rotation = gameObject.GetComponent<Rotation>();
        resizing = gameObject.GetComponent<Resizing>();
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
        // When the slider is activated, set the value of the slider according to the object's speed
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

    // Apply the change by the value on the slider
    public void SliderChange(float value)
    {
        if (!(rotation is null))
        {
            rotation.speed = rotation.minSpeed + value * (rotation.maxSpeed - rotation.minSpeed);
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
