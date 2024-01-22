using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraSwitch : MonoBehaviour
{
    public Camera initialCamera;
    public Camera secondCamera;
    public float delayTime = 5f; 

    void Start()
    {
        
        secondCamera.enabled = false;
        
        Invoke("SwitchCamera", delayTime);
    }

    void SwitchCamera()
    {
        
        initialCamera.enabled = false;
        secondCamera.enabled = true;
    }
}
