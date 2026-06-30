using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D hitbox;

    public float moveSpeed;
    public float jumpForce;
    public float horizontal;

    //Input Action References
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference crouch;
    [SerializeField] private InputActionReference jump;

    private bool crouchHeld = false;
    private bool pressedJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        crouch.action.started += startCrouch => crouchHeld = true;
        crouch.action.canceled += endCrouch => crouchHeld = false;

        jump.action.started += Jump => pressedJump = true; ;
    }

    

    private void OnDisable()
    {
        crouch.action.started -= startCrouch => crouchHeld = true;
        crouch.action.canceled -= endCrouch => crouchHeld = false;

        jump.action.started -= Jump => pressedJump = true; ;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = move.action.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        Grounded();
    }

    //Grounded Functions
    private void Grounded()
    {
        //Crouch Code (Work in Progress)
        if (crouchHeld)
        {
            anim.SetBool("isCrouching", true);
            Debug.Log("Crouching");
        }
        else
        {
            anim.SetBool("isCrouching", false);
        }
        //End

        //Jump Code (Work in Progress)
        if (pressedJump)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
            pressedJump = false;
            Debug.Log("Jumped");
        }
        //End
    }

    //Air Functions

    //helpers
    public bool IsGrounded()
    {

    }
}
