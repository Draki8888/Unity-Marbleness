using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CinemachineFreeLook camera;
    
    private Rigidbody rigidbody;
    private float xInput;
    private float zInput;

    // Jumping variables
    [SerializeField] private float jumpForce = 110f;

    [SerializeField] private Transform cam; // Reference to the camera transform
    [SerializeField] private float rotationForce;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = 40;

        cam = Camera.main.transform; // Get the main camera transform

        Cursor.visible = false;
    }

    private void Start()
    {
        camera.m_XAxis.m_MaxSpeed = 1500;
    }

    void Update()
    {
        ProcessInputs();
        Move();
    }


    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        rigidbody.AddTorque(
            zInput * rotationForce,
            0, 
            -xInput * rotationForce
        );
    }
}