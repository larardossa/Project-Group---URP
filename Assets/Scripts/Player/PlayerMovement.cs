using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidBody;
    private Camera mainCamera;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>(); // Get the rigidbody component
        mainCamera = Camera.main; // Get the main camera
    }

    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal"); // Get the horizontal input
        float verticalInput = Input.GetAxis("Vertical"); // Get the vertical input

        var movement = new Vector3(horizontalInput, 0, verticalInput); // Create a vector for the movement
              

        Quaternion camRotation = mainCamera.transform.rotation; // Get the camera rotation
        Vector3 targetDirection = camRotation * movement; // Get the direction of the movement
        targetDirection.y = 0; // Set the y to 0 to prevent the player from moving up and down
        targetDirection.Normalize(); //  // Normalize the movement vector which will prevent the player from moving faster diagonally\

        rigidBody.MovePosition(transform.position + targetDirection * speed * Time.fixedDeltaTime); // Move the player
        rigidBody.MoveRotation(Quaternion.Euler(0, camRotation.eulerAngles.y, 0)); // Rotate the player to the direction of the movement
    }
}
