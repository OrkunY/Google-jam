using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMovement : MonoBehaviour
{
    
    
    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector2 movement;

    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Horizontal", movement.x);
        
        animator.SetFloat("Speed", movement.sqrMagnitude);

        spriteRenderer.flipX = movement.x < 0.01 ? true : false;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
