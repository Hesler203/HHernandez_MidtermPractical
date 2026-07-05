using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput;
    private float depthInput;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityMultiplier;
    private bool grounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        rb.maxLinearVelocity = maxSpeed;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        depthInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        if (grounded)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, depthInput).normalized;
            rb.AddRelativeForce(moveDirection * speed, ForceMode.Acceleration);
        }
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            grounded = true;
        }

    }

}
