using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Camera playerCamera;
    private Rigidbody rb;

    void Start()
    {
        // Assuming the camera is a child of the player
        playerCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Transform input to be relative to the camera
        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;

        cameraForward.y = 0; // Ignore vertical component for simplicity
        cameraForward.Normalize();

        Vector3 movement = (cameraForward * vertical + cameraRight * horizontal).normalized;
        transform.Translate(movement * speed * Time.deltaTime);

        //// Apply torque for rolling effect
        //rb.AddTorque(Vector3.Cross(transform.up, movement) * speed, ForceMode.Acceleration);

        // Jumping
        if (Input.GetButtonDown("Jump") && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) < 0.001f)
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
        //    // Handle collision with obstacles
        //}
    }
}