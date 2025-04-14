using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float speed;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    private void Update()
    {
        playerCamera.transform.position -= Input.mouseScrollDelta.y * -speed * transform.forward * Time.deltaTime;
        if(playerCamera.localPosition.z > minRange) playerCamera.localPosition = new Vector3(playerCamera.localPosition.x, playerCamera.localPosition.y, minRange);
        if(playerCamera.localPosition.z < maxRange) playerCamera.localPosition = new Vector3(playerCamera.localPosition.x, playerCamera.localPosition.y, maxRange);
    }
}
