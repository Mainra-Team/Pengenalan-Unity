using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;

    public bool isGrounded;

    public Rigidbody2D rb;

    //setup isgrounded
    public Transform groundCheck;
    public float distance = .1f;
    public LayerMask enviLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, distance, enviLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * 500);
            }
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(x * speed, rb.velocity.y);

        rb.velocity = dir;

    }
}
