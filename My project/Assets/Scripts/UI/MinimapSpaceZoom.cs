using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapSpaceZoom : MonoBehaviour
{
    [SerializeField] private Camera minimapCamera;
    [SerializeField] private float cameraMinSize;
    [SerializeField] private Transform cameraPosition, playerPosition;
    [SerializeField][Range(0, 1)] private float zoomSpeed = 0.5f;
    private float zoom;
    private Vector3 cameraInitialPosition, zoomDirection;
    private float cameraInitialSize;
    private void Start()
    {
        cameraInitialPosition = cameraPosition.position;
        cameraInitialSize = minimapCamera.orthographicSize;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Equals)) SetZoom(1);
        else if(Input.GetKey(KeyCode.Minus)) SetZoom(-1);
        else SetZoom(0);
    }
    private void SetZoom(int direction)
    {
        zoom += direction * zoomSpeed * Time.deltaTime;
        zoom = Mathf.Clamp(zoom, 0, 1);
        zoomDirection = ((playerPosition.position - cameraInitialPosition) * zoom) + cameraInitialPosition;
        cameraPosition.position = new Vector3(zoomDirection.x, cameraInitialPosition.y, zoomDirection.z);
        minimapCamera.orthographicSize = ((cameraMinSize - cameraInitialSize) * zoom) + cameraInitialSize;
    }
}
