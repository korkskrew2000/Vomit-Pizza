using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public Vector3 minValue, maxValue;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
            Mathf.Clamp(0, 0, 0));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, 1 * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
