using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipCameraNew : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject scoutCamera;
    [SerializeField] private GameObject pilotCamera;
    [Header("Values")]
    [SerializeField] private CameraStyle currentCamera;
    [SerializeField] private enum CameraStyle{Scout, Pilot}
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SwitchCameraStyle(CameraStyle.Scout);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Scout);
        if(Input.GetKeyDown(KeyCode.Alpha2)) SwitchCameraStyle(CameraStyle.Pilot);
    }
    private void SwitchCameraStyle(CameraStyle newStyle)
    {
        scoutCamera.SetActive(false);
        pilotCamera.SetActive(false);

        if(newStyle == CameraStyle.Scout) scoutCamera.SetActive(true);
        else if(newStyle == CameraStyle.Pilot) pilotCamera.SetActive(true);

        currentCamera = newStyle;
    }
}
