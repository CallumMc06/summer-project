using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;

    private Vector2 moveDirection;

    public InputActionReference move;

    public InputActionReference fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnEnable()
    {
        fire.action.started += Fire;
    }

    private void OnDisable()
    {
        fire.action.started -= Fire;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }
}
