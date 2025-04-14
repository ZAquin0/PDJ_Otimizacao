using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarLanderCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float threshold;
    private Vector3 offset;
    private void Start() => offset = this.transform.position;
    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cameraPosition = (player.position + mousePosition) / 2f;
        Vector3 PlayerToCamera = cameraPosition - player.position;
        if(PlayerToCamera.magnitude > threshold) cameraPosition = PlayerToCamera.normalized * threshold + player.position;
        this.transform.position = cameraPosition + offset;
    }
}
