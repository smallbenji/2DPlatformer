using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private bool facingRight;
    private float moveInput;

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        
        if (moveInput > 0 && facingRight)
        {
            Flip();
        }
        if (moveInput < 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
