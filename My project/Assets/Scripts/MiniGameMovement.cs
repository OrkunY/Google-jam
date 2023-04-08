using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMovement : MonoBehaviour
{
    
    
    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    
    private Vector2 movement;

    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
