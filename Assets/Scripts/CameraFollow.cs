using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float offsetHeight;
    [SerializeField] private float distance;
    [SerializeField] private GameObject cameraa;

    public float cameraRotationSpeed = 180f;
    

    private float currentRotationHorizontal;
    private float currentRotationVertical;
    


    private Vector3 baseOffsetVector;
    
    private void Awake()
    {
        baseOffsetVector = new Vector3(0, offsetHeight, -distance); 
    }

    private void Update()
    {
        ControlCamera();
       // cameraa.transform.position += Vector3.up * Input.GetAxisRaw("Mouse Y") * 200f * Time.deltaTime;

    }

    private void ControlCamera()
    {
        currentRotationHorizontal += cameraRotationSpeed * 2f * Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        currentRotationVertical += cameraRotationSpeed * 2f * Input.GetAxisRaw("Mouse Y") * Time.deltaTime;
        currentRotationVertical = Mathf.Clamp(currentRotationVertical, 0, 90);
        transform.position = target.transform.position;
        transform.rotation = Quaternion.Euler(currentRotationVertical, currentRotationHorizontal, 0);
        transform.position -= transform.forward * distance;
        


        
    }
}
