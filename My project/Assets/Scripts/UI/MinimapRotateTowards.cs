using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapRotateTowards : MonoBehaviour
{
    [SerializeField] private Transform playerMinimapCursorIcon;
    private void Update()
    {
        Vector3 direction = this.GetComponent<Rigidbody>().linearVelocity;
        playerMinimapCursorIcon.rotation = Quaternion.LookRotation(new Vector3(-direction.x , 0, -direction.z), Vector3.up);
    }
}
