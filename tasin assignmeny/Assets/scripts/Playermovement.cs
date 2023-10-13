using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private playerInputManager inputManager;
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float groundDistance = 1f;
    [SerializeField] private float moveSpeed = 5f;
    
    private void Start()
    {
        inputManager = GetComponent<playerInputManager>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    public void HandleJumping()
    {
       if (isGrounded()) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    private void HandleMovement()
    {
        float horizontalInput = inputManager.HorizontalInput;
        float verticalInput = inputManager.VerticalInput;

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveVelocity = moveDirection * moveSpeed;

        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }
    
}
