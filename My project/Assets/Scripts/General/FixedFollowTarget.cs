using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    private void FixedUpdate() => transform.position += target.position - transform.position;
}
