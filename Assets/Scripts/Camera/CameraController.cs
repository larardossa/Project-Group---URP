using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    CinemachineFreeLook CinemachineFreeLook;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))    // Right mouse button, this if statement checks if the right mouse button is pressed and when is released it stops the camera movement if it is down you can move the camera, however if it is up you can't move the camera
        {
            CinemachineFreeLook.m_XAxis.m_MaxSpeed = 400;
            CinemachineFreeLook.m_YAxis.m_MaxSpeed = 10;
        }
        if (Input.GetMouseButtonUp(1))
        {
            CinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
            CinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
        }
    }
}
