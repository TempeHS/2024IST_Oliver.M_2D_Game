using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
private float horizontal;
private float speed = 8f;
private float jumpingPower = 16f;
private bool isFacingRight = true;

[SerializeField] private Rigidbody2D rb;
[SerializeField] private Transform groundcheck;
[SerializeField] private LayerMask groundlayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Flip();
    }

    private void FixedUpdate()
     {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
     }

     private bool IsGrounded()
     {
        return Physics2D.OverlapCircle();
     }

     private void Flip()
     {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    
     }

}
