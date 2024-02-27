using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderRotation : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public bool rotateClockwise = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }
    
    void RotateObject()
    {
        float targetRotation = rotateClockwise ? 15f : -15f;
        float currentRotation = transform.eulerAngles.z;

        if (Mathf.Abs(currentRotation - targetRotation) > 0.1f)
        {
            float rotationDirection = rotateClockwise ? 1f : -1f;
            transform.Rotate(Vector3.forward * rotationDirection * rotationSpeed * Time.deltaTime);
        }
        else
        {
            rotateClockwise = !rotateClockwise; // Switch rotation direction
        }
    }
}

