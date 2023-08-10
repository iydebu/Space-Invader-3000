using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCamera;
    private int currentCameraIndex = 0;

    private void Start()
    {
        for(int i=0; i < virtualCamera.Length; i++)
        {
            virtualCamera[i].Priority = i== currentCameraIndex ? 1 : 0;
        }
    }

    public void SwitchCamera()
    {
        virtualCamera[currentCameraIndex].Priority = 0;

        currentCameraIndex++;
        if(currentCameraIndex >= virtualCamera.Length)
        {
            currentCameraIndex = 0;
        }
        virtualCamera[currentCameraIndex].Priority = 1;
    }
}
