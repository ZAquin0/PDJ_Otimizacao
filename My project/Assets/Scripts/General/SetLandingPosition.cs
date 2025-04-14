using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLandingPosition : MonoBehaviour
{
    [SerializeField] private Vector2 minPositionLimit;
    [SerializeField] private Vector2 maxPositionLimit;
    [SerializeField] private float startinHeight;
    [SerializeField][Range(0, 360)] private float maxAngle;
    private void Start()
    {
        Vector3 randomPosition;
        randomPosition.x = Random.Range(minPositionLimit.x, maxPositionLimit.x);
        randomPosition.y = startinHeight;
        randomPosition.z = Random.Range(minPositionLimit.y, maxPositionLimit.y);
        this.transform.position = randomPosition;

        float randomAngleX = Random.Range(-maxAngle, maxAngle);
        float randomAngleZ = Random.Range(-maxAngle, maxAngle);
        this.transform.rotation = Quaternion.AngleAxis(180, Vector3.right) * this.transform.rotation;
        this.transform.rotation = Quaternion.AngleAxis(randomAngleX, Vector3.right) * Quaternion.AngleAxis(randomAngleZ, Vector3.forward) * this.transform.rotation;
    }
}
