using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
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
        transform.eulerAngles = newAngle;
    }

    public void TranslateOrb()
    {

    }

    public void ScaleOrb()
    {

    }
}
