using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float offsetHeight;
    [SerializeField] private float distance;

    [SerializeField] private float cameraRotationSpeed = 90f;

    private float currentRotation;

    private Vector3 baseOffsetVector;
    
    private void Awake()
    {
        baseOffsetVector = new Vector3(0, offsetHeight, -distance);
    }

    private void Update() {
        currentRotation += cameraRotationSpeed * Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        
        Vector3 targetPosition = target.transform.position;

        Vector3 rotatedOffset = Quaternion.AngleAxis(currentRotation, Vector3.up) * baseOffsetVector;
        transform.position = targetPosition + rotatedOffset;

        transform.LookAt(targetPosition);
    }
}
