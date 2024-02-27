using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCatapult : MonoBehaviour
{
    public float deletionRadius = 1.0f;
    public GameObject itemToDelete;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, itemToDelete.transform.position);
        
        if (distance < deletionRadius)
        {
            Destroy(itemToDelete);
        }
    }
}
