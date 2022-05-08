using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform SpaceShip;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = SpaceShip.position+offset;
    }
}
