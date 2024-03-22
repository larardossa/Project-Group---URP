using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushesScript : MonoBehaviour
{
    private static PlayerMovement playerMovement = null;
    private void OnTriggerEnter(Collider other)
    {
        playerMovement.isInsideBush = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerMovement.isInsideBush = false;
    }
    private void Awake()
    {
        if (playerMovement == null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerMovement>();
        }
    }
}
