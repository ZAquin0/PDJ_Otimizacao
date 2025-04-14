using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipRotation : MonoBehaviour
{
    [SerializeField] private Transform cameraPost;
    [SerializeField][Range(0.0000000001f, 100)] private float rotationSensitivity;
    private PlayerShipCamera playerShipCamera;
    private Rigidbody rigidbody;
    private Vector2 objectTurn;
    private void Start()
    {
        playerShipCamera = GetComponent<PlayerShipCamera>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            playerShipCamera.isActive = false;
            RotateObject();
        }
        else playerShipCamera.isActive = true;
    }
    private void RotateObject()
    {
        objectTurn.x = Input.GetAxis("Mouse X") * rotationSensitivity;
        objectTurn.y = Input.GetAxis("Mouse Y") * rotationSensitivity;
        rigidbody.AddTorque(cameraPost.forward * objectTurn.x);
        rigidbody.AddTorque(cameraPost.right * objectTurn.y);
    }
}
