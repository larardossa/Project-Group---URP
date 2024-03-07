using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSwapScript : MonoBehaviour
{
    public GameObject[] shapes; // Array to hold all the shape prefabs
    private int currentShapeIndex = 0; // Index of the current shape - the player


    GameObject chickenObject;

    private void Awake()
    {
        chickenObject = GameObject.Find("Chicken");
        chickenObject.SetActive(false);
    }


    void Update()
    {
        // Example: Press 'Space' to switch shape
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShiftShape();
        }
    }

    public void ShiftShape()
    {
        //Get the position and rotation of the current player
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        GameObject newShape = Instantiate(shapes[currentShapeIndex + 1], currentPosition, currentRotation);
        
        chickenObject.SetActive(true);
        Destroy(shapes[0]);

        // make a way to store the current shape
    }
}
