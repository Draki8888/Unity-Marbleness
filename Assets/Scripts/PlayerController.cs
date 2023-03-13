using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera gameCamera;
    private Rigidbody playerRigidbody;
    private float xInput;
    private float zInput;
    private bool isGrounded;
    
    [SerializeField] private float jumpForce = 110f;
    [SerializeField] private float rotationForce;

    void Awake()
    {
        gameCamera = FindAnyObjectByType<Camera>();

        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.maxAngularVelocity = 40;

        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessInputs();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void Move()
    {
        Vector3 relativeMovementDirection = new Vector3(xInput, 0, zInput);
        Vector3 movementDirection = gameCamera.transform.TransformDirection(relativeMovementDirection);
        movementDirection.y = 0;
        movementDirection.Normalize();
        Vector3 rotationVector = new Vector3(movementDirection.z, 0, -movementDirection.x);
        playerRigidbody.AddTorque(rotationVector * rotationForce);
    }
}