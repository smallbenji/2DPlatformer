using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    
    /*
        Ayo you're reading this, nice you're now learning to discover code.
        
        This is the Animation script 😊
    */
    
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
