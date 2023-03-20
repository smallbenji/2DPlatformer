using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator m_Animator;
    public Rigidbody2D rb;

    private void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetFloat("Speed", Input.GetAxisRaw("Horizontal"));
    }
}
