using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float scaleUpper = 0.03f;
    public float scaleLower = 0.01f;
    public float lastDistance = 0;
    public float initialDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateOrb(Transform target)
    {
        transform.LookAt(target);
        var angle = transform.eulerAngles;
        var newAngle = new Vector3(0, angle.y, 0);
        transform.localEulerAngles = newAngle;
    }

    public void RotateArrow(Vector3 direction)
    {
        var newAngle = new Vector3(0, direction.y, 0);
        transform.localEulerAngles = newAngle;
    }

    public void TranslateOrb(Transform target)
    {
        transform.position = target.position;
    }

    public void Scale(Transform target)
    {
        var heading = target.transform.position - transform.position;
        var distance = heading.magnitude;
        var deltaDistance = distance - lastDistance;
        var oldscale = transform.localScale.x;
        var newScale = oldscale + (scaleUpper - scaleLower) * deltaDistance / initialDistance;
        if (newScale > scaleUpper)
            newScale = scaleUpper;
        else if(newScale < scaleLower)
            newScale = scaleLower;
        Debug.Log((distance, deltaDistance, newScale));
        transform.localScale = new Vector3(newScale, newScale, newScale);
        lastDistance = distance;
    }
}
