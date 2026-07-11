using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput;
    private float depthInput;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float runForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityMultiplier;
    private bool grounded;

    /// <summary>
    /// Initialize the player rigidbody reference & set physics limits for the player.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        rb.maxLinearVelocity = maxSpeed;
    }

    /// <summary>
    /// Detects player input in horizontal & vertical axis.
    /// </summary>
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        depthInput = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Calls for physics movements based on player input.
    /// </summary>
    void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }

    /// <summary>
    /// Applies a constant running force for movement in the x & z axis
    /// based on player input for direction only if the player is on the ground.
    /// </summary>
    private void HandleMovement()
    {
        if (grounded)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, depthInput).normalized;
            rb.AddRelativeForce(moveDirection * runForce, ForceMode.Acceleration);
        }
    }

    /// <summary>
    /// Applies a vertical impulse force to the player when jump is pressed & they are on the ground.
    /// </summary>
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    /// <summary>
    /// Sets the gounded flag to true whenever the player is on the ground, for jump checks.
    /// </summary>
    /// <param name="other">the object involved in the collision with the player</param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
