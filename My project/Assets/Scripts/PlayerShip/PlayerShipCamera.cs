using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCameraPost;
    [SerializeField][Range(0.001f, 5)] private float cameraTurnSensibility;
    [HideInInspector] public bool isActive = true;
    private Vector2 cameraTurn;
    private void OnEnable() => Cursor.lockState = CursorLockMode.Locked;
    private void Update()
    {
        if(isActive) LookAt();
    }
    private void LookAt()
    {
        cameraTurn.x += Input.GetAxis("Mouse X") * cameraTurnSensibility;
        cameraTurn.y += Input.GetAxis("Mouse Y") * cameraTurnSensibility;
        playerCameraPost.localRotation = Quaternion.Euler(-cameraTurn.y, cameraTurn.x, 0);
    }
}
