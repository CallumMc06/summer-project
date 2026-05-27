using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;

    private Vector2 moveDirection;

    public InputActionReference move;
    public InputActionReference crouch;
    public InputActionReference jump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnEnable()
    {
        crouch.action.started += Crouch;
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        crouch.action.started -= Crouch;
        jump.action.started -= Jump;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        Debug.Log("Crouch");
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
    }
}
