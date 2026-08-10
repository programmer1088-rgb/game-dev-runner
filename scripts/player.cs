using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;

    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 12f;

    [Header("Components")]
    [SerializeField] private Animator animator;

    private bool _jumpRequested;
    private bool _isGrounded;

    private void Awake()
    {
        // Automatically get components if not assigned in Inspector
        if (_rb2d == null)
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        // 1. Detect Space bar press while grounded
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _jumpRequested = true;
        }

        // 2. Keep the Animator updated on ground state
        // When true -> Idle/Grounded state
        // When false -> Jump/Airborne state
        if (animator != null)
        {
            animator.SetBool("isGrounded", _isGrounded);
        }
    }

    private void FixedUpdate()
    {
        // Apply jump velocity when requested
        if (_jumpRequested)
        {
            _rb2d.linearVelocity = new Vector2(_rb2d.linearVelocity.x, _jumpForce);

            // Trigger the jump animation
            if (animator != null)
            {
                animator.SetTrigger("jump");
            }

            _jumpRequested = false;
            _isGrounded = false; // FIXED: Set to false so the airborne state stays active while jumping!
        }
    }

    // Ground Check: Switches back to Idle when touching ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    // Leaves ground: Ensures airborne state is active if player falls off a ledge
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}