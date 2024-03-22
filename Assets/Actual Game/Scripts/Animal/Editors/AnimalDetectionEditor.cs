using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimalDetectRange))]
public class AnimalDetectionEditor : Editor
{
    private void OnSceneGUI()
    {
        AnimalDetectRange m_detection = (AnimalDetectRange)target;

        Color c = Color.green;

        if (m_detection.alertStage == AlertStage.Intrigued)
        {
            c = Color.Lerp(Color.green, Color.red, m_detection.alertLevel / 100.0f);
        }
        else if (m_detection.alertStage == AlertStage.Alerted)
        {
            c = Color.red;
        } 

        Handles.color = new Color(c.r, c.g, c.b, 0.3f);       
        Handles.DrawSolidDisc(m_detection.transform.position, m_detection.transform.up, m_detection.FieldOfVision);

        Handles.color = c;
        m_detection.FieldOfVision = Handles.ScaleValueHandle(m_detection.FieldOfVision, m_detection.transform.position + m_detection.transform.forward * m_detection.FieldOfVision, m_detection.transform.rotation, 3, Handles.SphereHandleCap, 1);
    }
}
