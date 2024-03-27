using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
public enum AlertStage
{
    Peaceful,
    Intrigued,
    Alerted
}

public class AnimalDetectRange : MonoBehaviour
{
    public float FieldOfVision;

    public AlertStage alertStage;
    [Range(0, 100)] public float alertLevel; // 0 - Peaceful, 100 - Alerted (min, max)
    private static PlayerMovement playerMovement = null;

    private void Awake()
    {     
        if (playerMovement == null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerMovement>();
        }
    }
    private void Start()
    {
        alertStage = AlertStage.Peaceful;
        alertLevel = 0;
     
        Debug.Log("AnimalDetectRange Awake");      
    }
    private void Update()
    {
        
        bool playerInSight = false;
        

        if (!playerMovement.isHidden && !playerMovement.isInsideBush)
        {
            Collider[] targetsInFov = Physics.OverlapSphere(transform.position, FieldOfVision);

            foreach (Collider colls in targetsInFov)
            {
                if (colls.CompareTag("PlayerController"))
                {
                    Debug.Log("Player in sight");
                    playerInSight = true;
                    break;
                }
            }
        }
        UpdateAlertStage(playerInSight);
    }
    private void UpdateAlertStage(bool playerInSight)
    {
        switch (alertStage)
        {
            case AlertStage.Peaceful:
                if (playerInSight)
                {
                    alertStage = AlertStage.Intrigued;
                    Debug.Log("Intrigued");
                }
                break;
            case AlertStage.Intrigued:
                if (playerInSight)
                {
                    alertLevel++;
                    if (alertLevel >= 100)
                    {
                        alertStage = AlertStage.Alerted;
                        Debug.Log("Alerted");
                    }
                }
                else
                {
                    alertLevel--;
                    if (alertLevel <= 0)
                    {
                        alertStage = AlertStage.Peaceful;
                        Debug.Log("Peaceful");
                    }
                }
                break;
            case AlertStage.Alerted:
                if (!playerInSight)
                {
                    alertStage = AlertStage.Intrigued;
                }
                break;
        }
    }
}
