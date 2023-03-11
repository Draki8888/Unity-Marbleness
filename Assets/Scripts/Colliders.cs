using UnityEngine;

public class CollisionHandler : MonoBehaviour {
    public float minForce = 0f;
    public float maxForce = 20f;
    private float jumpForce = 28f;


    private void OnCollisionEnter(Collision collision) {
        float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;

        float force = Mathf.Clamp(collisionForce, minForce, maxForce);

        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null) {
            rb.AddForce(-collision.contacts[0].normal * force, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * force, ForceMode.Impulse);
            
        }
    }
}