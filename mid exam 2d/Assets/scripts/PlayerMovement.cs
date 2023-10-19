using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private Transform playerFeet;
    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, groundDistance, groundLayer);
        float movementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movementInput * moveSpeed, rb.velocity.y);
        if (movementInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movementInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    }
