using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    public float distance;

    public float targetHeight;

    private float x = 0.0f;

    private float y = 0.0f;

    void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }

    void LateUpdate()
    {
        if(!target)
        {
            return;
        }
        y = target.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(x, y, 0);
        transform.rotation = rotation;

        Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, targetHeight, 0));
        transform.position = position;
    }
}
