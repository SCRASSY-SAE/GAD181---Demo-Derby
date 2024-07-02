using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    Camera m_MainCamera;
    public Camera m_CameraTwo;

    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;
        m_CameraTwo.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (m_MainCamera.enabled)
            {
                m_CameraTwo.enabled = true;
                m_MainCamera.enabled = false;
            }
            else if (!m_MainCamera.enabled)
            {
                m_CameraTwo.enabled = false;
                m_MainCamera.enabled = true;
            }
        }
    }
}
