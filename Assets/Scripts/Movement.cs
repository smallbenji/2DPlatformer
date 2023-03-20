using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed = 10;
    public float jumpForce = 5;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Vector2 checkBoxSize = new Vector2(0.5f, 0.2f);


    private bool facingRight;
    private float moveInput;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer _renderer;
    private bool isGrounded;
    private Animator _animator;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkBoxSize, 0f, groundLayer);
        
        _animator.SetFloat("Speed", Mathf.Abs(moveInput * playerSpeed));

        
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }
        
        _animator.SetBool("isJumping", !isGrounded);

        if (moveInput * playerSpeed > 0 && facingRight)
        {
            flip();
        }
        if (moveInput * playerSpeed < 0 && !facingRight)
        {
            flip();
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveInput * playerSpeed, rigidbody2D.velocity.y);
    }

    private void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
