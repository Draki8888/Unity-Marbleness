using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float offsetHeight;
    [SerializeField] private float distance;

    public float cameraRotationSpeed;

    private float currentRotation;

    private Vector3 baseOffsetVector;
    
    private void Awake()
    {
        baseOffsetVector = new Vector3(0, offsetHeight, -distance); 
    }

    void Start() 
    {
        cameraRotationSpeed = PlayerPrefs.GetFloat("SensitivityValue") * 2f;
        Debug.Log(PlayerPrefs.GetFloat("SensitivityValue"));
    }

    private void Update()
    {
        ControlCamera();
    }

    private void ControlCamera()
    {
        currentRotation += cameraRotationSpeed * 2f * Input.GetAxisRaw("Mouse X") * Time.deltaTime;

        Vector3 targetPosition = target.transform.position;
        Vector3 rotatedOffset = Quaternion.AngleAxis(currentRotation, Vector3.up) * baseOffsetVector;
        transform.position = targetPosition + rotatedOffset;
        transform.LookAt(targetPosition);
    }
}
