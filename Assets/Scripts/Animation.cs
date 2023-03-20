using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    public LayerMask groundLayer;
    public Vector2 checkBoxSize = new Vector2(0.5f, 0.2f);

    private Animator _animator;
    public bool isGrounded;
    public Transform groundCheck;
    
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkBoxSize, 0f, groundLayer);
        _animator.SetBool("isJumping", !isGrounded);

        _animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }
}
