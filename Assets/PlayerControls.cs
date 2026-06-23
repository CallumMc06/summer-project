using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public float moveSpeed;
    private Vector2 moveDirection;

    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference crouch;
    [SerializeField] private InputActionReference jump;

    private bool crouchHeld = false;
    private bool pressedJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (crouchHeld)
        {
            anim.SetBool("isCrouching", true);
            Debug.Log("Crouching");
        }
        else
        {
            anim.SetBool("isCrouching", false);
            Debug.Log("Standing");
        }
    }
}
