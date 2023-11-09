using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Playermovement : MonoBehaviour
{
    private playerInputManager inputManager;
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float groundDistance = 1f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private CinemachineFreeLook freeLookCam;
    private Transform cam;
    
    private void Start()
    {
        inputManager = GetComponent<playerInputManager>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
        HandleRotation();
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

        Vector3 moveDirection = cam.forward * verticalInput + cam.right * horizontalInput; 
        moveDirection.Normalize();
        Vector3 moveVelocity = moveDirection * moveSpeed;

        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }

    private void HandleRotation()
    {
        Quaternion targetRot = freeLookCam.State.FinalOrientation;
        Quaternion newRot = new Quaternion(0f, targetRot.y, 0f, targetRot.w);
        transform.rotation = newRot;
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }
    
}
