using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range;

    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range), Color.green);

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag("Horse") || (hit.collider.CompareTag("Chicken"))) 
            {
                Debug.Log("Hit an animal");
            }
        }
    }
}
