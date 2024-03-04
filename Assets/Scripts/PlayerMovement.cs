using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody m_Rb;
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>(); // Get the rigidbody component
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get the horizontal input
        float verticalInput = Input.GetAxis("Vertical"); // Get the vertical input

        var movement = new Vector3(horizontalInput, 0, verticalInput); // Create a vector for the movement
        movement.Normalize(); // Normalize the movement vector which will prevent the player from moving faster diagonally
        
        m_Rb.MovePosition(transform.position + movement * speed * Time.deltaTime); // Move the player

        if (movement == Vector3.zero) //if the player is not moving
        {
            return;
        }
    }
}
