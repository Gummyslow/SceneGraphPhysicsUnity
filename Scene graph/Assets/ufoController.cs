using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoController : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float orbitSpeed = 2f;
    public float orbitRadius = 25f;
    
    public Vector3 orbitCenter = new Vector3(23f, 0f, 35f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the UFO around its own axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Move the UFO in a circular orbit
        float angle = Time.time * orbitSpeed;
        float x = orbitCenter.x + Mathf.Cos(angle) * orbitRadius;
        float z = orbitCenter.z + Mathf.Sin(angle) * orbitRadius;
        transform.position = new Vector3(x, 18f, z);
    }
}
