using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputManager : MonoBehaviour
{
    private Playermovement playerMovement;
    private PlayerControls playerControls;
    private bool jumpInput;
    private Vector2 movementInput;
    [HideInInspector] public float VerticalInput;
   [HideInInspector] public float HorizontalInput;
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.Default.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.Default.Jump.performed += i => jumpInput = true;
        }
        playerControls.Enable();
        playerMovement = GetComponent<Playermovement>();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleJumpingInput();
    }

    private void HandleMovementInput()
    {
        VerticalInput = movementInput.y;
        HorizontalInput = movementInput.x;
    }
    private void HandleJumpingInput()
    {
        if (jumpInput)
        {
            playerMovement.HandleJumping();
            jumpInput = false;
        }
    }
}