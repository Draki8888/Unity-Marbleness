using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float moveSpeed = 1f;
    private float xInput;
    private float zInput;
    public CinemachineFreeLook camera;

    // Jumping variables
    private float jumpForce = 110f;
    private bool isGrounded;


    [SerializeField] private Transform cam; // Reference to the camera transform

    // Start is called before the first frame update
    void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform; // Get the main camera transform

        Cursor.visible = false;
    }

    private void Start() {
        camera.m_XAxis.m_MaxSpeed = 1500;
    }

    void Update() {
        ProcessInputs();
        Move();

    }



    private void ProcessInputs() {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }
        
    private void Move() {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f);


        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

        // Movement
        Vector3 movementDir = cam.forward * zInput + cam.right * xInput;
        movementDir.y = 0;
        movementDir.Normalize();

        rb.AddForce(movementDir * moveSpeed, ForceMode.Impulse);
    }
}