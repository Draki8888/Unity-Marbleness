using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float xOffset, yOffset, zOffset;

    public float speedH = 2f;
    public float SpeedV = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update() {
       // transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
       // transform.LookAt(target.transform.position);

        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= SpeedV * Input.GetAxis("Mouse Y");

        //transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
