using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterCameraController : MonoBehaviour
{
    [SerializeField] private Transform playerCameraPost;
    [SerializeField][Range(1f, 5f)] private float cameraTurnSensibility = 1;
    [SerializeField] private float minYAxis;
    [SerializeField] private float maxYAxis;
    [HideInInspector] public bool isActive = true;
    private Vector2 cameraTurn;
    private void OnEnable() => Cursor.lockState = CursorLockMode.Locked;
    private void FixedUpdate()
    {
        if(isActive) LookAt();
    }
    private void LookAt()
    {
        cameraTurn.x += Input.GetAxis("Mouse X") * cameraTurnSensibility;
        cameraTurn.y += Input.GetAxis("Mouse Y") * cameraTurnSensibility;
        playerCameraPost.localRotation = Quaternion.Euler(-cameraTurn.y, cameraTurn.x, 0);
        if(cameraTurn.y > maxYAxis) cameraTurn.y = maxYAxis;
        if(cameraTurn.y < minYAxis) cameraTurn.y = minYAxis;
        transform.localRotation = Quaternion.Euler(0, cameraTurn.x, 0);
    }
}
