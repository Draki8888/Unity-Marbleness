using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float xInput;
    private float zInput;

    [SerializeField] private float jumpForce = 110f;
    [SerializeField] private float rotationForce;

    void Awake()
    {
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
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        playerRigidbody.AddTorque(
            zInput * rotationForce,
            0, 
            -xInput * rotationForce
        );
    }
}