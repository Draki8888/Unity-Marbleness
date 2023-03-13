using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera gameCamera;
    private Rigidbody playerRigidbody;
    private float xInput;
    private float zInput;

    [SerializeField] private float jumpForce = 110f;
    [SerializeField] private float rotationForce;

    void Awake()
    {
        gameCamera = FindAnyObjectByType<Camera>();

        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.maxAngularVelocity = 40;

        Cursor.visible = false;
    }

    void Update()
    {
        ProcessInputs();
        Move();
    }


    private void ProcessInputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        Vector3 relativeMovementDirection = new Vector3(xInput, 0, zInput);
        Vector3 movementDirection = gameCamera.transform.TransformDirection(relativeMovementDirection);
        movementDirection.y = 0;
        movementDirection.Normalize();
        Vector3 rotationVector = new Vector3(movementDirection.z, 0, -movementDirection.x);
        playerRigidbody.AddTorque(rotationVector * rotationForce);
    }
}