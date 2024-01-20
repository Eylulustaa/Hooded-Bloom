using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;


    public LayerMask groundLayer;


    private Rigidbody2D rb;
    private Animator animator;


    private bool isGrounded;


    [HideInInspector]
    public SpriteRenderer spriteRenderer;




    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }



    void Update()
    {
        
        
          // BELK� D�NER�Z !!!  animator.SetBool("isJumping", !isGrounded);

            isGrounded = Physics2D.OverlapCircle(transform.position, 1, groundLayer);

            float moveInput = Input.GetAxisRaw("Horizontal");


            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (moveInput > 0.1f)
             {
                transform.rotation = Quaternion.Euler(0, 0, 0);
             } 
            else if (moveInput < -0.1f)
            {
                //spriteRenderer.flipX = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

             animator.SetBool("isWalking", moveInput !=0);

            // If the character is grounded and the jump button is pressed, add a force upwards to the Rigidbody
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

        

    }
}