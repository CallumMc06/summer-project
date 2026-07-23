using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerControls : MonoBehaviour
{
    //starters
    public Rigidbody2D rb;
    public Animator anim;

    //Moves
    public HitboxData LightPunch;

    //Random Variables
    public float moveSpeed;
    public float jumpForce;
    public float horizontal;

    public bool grounded;

    //Input Action References
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference crouch;
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference lite;

    //Enable Disable bools
    private bool crouchHeld = false;
    private bool pressedJump = false;

    private bool lightAttack = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        crouch.action.started += startCrouch => crouchHeld = true;
        crouch.action.canceled += endCrouch => crouchHeld = false;

        jump.action.started += Jump => pressedJump = true;

        lite.action.started += Lite => lightAttack = true;
    }

    

    private void OnDisable()
    {
        crouch.action.started -= startCrouch => crouchHeld = true;
        crouch.action.canceled -= endCrouch => crouchHeld = false;

        jump.action.started -= Jump => pressedJump = true;

        lite.action.started += Lite => lightAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = move.action.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        if (grounded)
        {
            GroundedActions();
        }
    }

    //Grounded Functions
    private void GroundedActions()
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

        //attacks
        if (lightAttack)
        {
            anim.SetTrigger("lightAttacking");
            lightAttack = false;
            Debug.Log("Light");
        }
        //End
    }

    //Air Functions

    //Collision Management
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("grounded");
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("not");
            grounded = false;
        }
    }
}
