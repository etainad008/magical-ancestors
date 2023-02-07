using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Xmove;
    private float Ymove;
    [SerializeField] float playerSpeed;

    private Vector2 moveDirection;
    private Vector2 velocityVector;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        HandleMovement();
    }

    private void HandleMovement()
    {
        HandleInput();

        // Set movement direction
        moveDirection = new Vector2(Xmove, Ymove);
        moveDirection = moveDirection.normalized;
        
        // Set velocity vector
        velocityVector = moveDirection * playerSpeed;

        // Move player to the new position
        rb.MovePosition(rb.position + velocityVector * Time.fixedDeltaTime);
    }

    private void HandleInput()
    {
        // Get axis raw
        Xmove = Input.GetAxisRaw("Horizontal");
        Ymove = Input.GetAxisRaw("Vertical");
    }
}
