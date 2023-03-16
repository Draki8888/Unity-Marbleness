using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Camera gameCamera;
    private Rigidbody playerRigidbody;
    private float xInput;
    private float zInput;
    private bool isGrounded;

    [SerializeField] private float jumpForce = 110f;
    [SerializeField] private float rotationForce;
    [SerializeField] private float accelerationSpeed;

    void Awake() {
        gameCamera = FindAnyObjectByType<Camera>();

        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.maxAngularVelocity = 53;

        Cursor.visible = false;
    }

    private void Update() {
        ProcessInputs();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
        Debug.Log(playerRigidbody.velocity);

    }

    private void FixedUpdate() {
        Move();
    }

    private void ProcessInputs() {

        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Vector3 relativeMovementDirection = new Vector3(xInput, 0, zInput);
        Vector3 movementDirection = gameCamera.transform.TransformDirection(relativeMovementDirection);

        if (Input.GetKey(KeyCode.W)) {
            playerRigidbody.AddForce(movementDirection * accelerationSpeed, ForceMode.Force);

        }

        if (Input.GetKey(KeyCode.S)) {
            playerRigidbody.AddForce(movementDirection * accelerationSpeed / 2, ForceMode.Force);

        }

        if (Input.GetKey(KeyCode.D)) {
            playerRigidbody.AddForce(movementDirection * accelerationSpeed / 2.5f, ForceMode.Force);

        }
        if (Input.GetKey(KeyCode.A)) {
            playerRigidbody.AddForce(movementDirection * accelerationSpeed / 2.5f, ForceMode.Force);

        }




    }
    private void Move() {
        Vector3 relativeMovementDirection = new Vector3(xInput, 0, zInput);
        Vector3 movementDirection = gameCamera.transform.TransformDirection(relativeMovementDirection);
        movementDirection.y = 0;
        movementDirection.Normalize();
        Vector3 rotationVector = new Vector3(movementDirection.z, 0, -movementDirection.x);
        playerRigidbody.AddTorque(rotationVector * rotationForce);

    }
}