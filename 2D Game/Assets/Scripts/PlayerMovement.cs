using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
private float horizontal;
private float speed = 10f;
private float jumpingPower = 14f;
private bool isFacingRight = true;

private float coyoteTime = 0.2f;
private float coyoteTimeCounter;

private float jumpBufferTime = 0.2f;
private float jumpBufferCounter;

[SerializeField] private Rigidbody2D rb;
[SerializeField] private Transform groundCheck;
[SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            speed = 10;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
            speed = 10;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;
        }

        Flip();
    }

    private void FixedUpdate()
     {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
     }

     private bool IsGrounded()
     {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
     }

     private void Dash()
     {
        if (Input.GetButtonDown("Up"))
        {
            speed = 10;
        }
        if (Input.GetButtonUp("Up"))
        {
            speed = 10;
        }
     }

     private void Flip()
     {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    
     }

}
