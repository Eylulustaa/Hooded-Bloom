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

    public AudioClip jumpSound;
    private AudioSource audioSource;


    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }



    void Update()
    {
        animator.SetBool("isJumping", !isGrounded);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, groundLayer);     
        isGrounded = hit.collider != null && hit.collider.CompareTag("Ground");

        float moveInput = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } 
        else if (moveInput < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

             animator.SetBool("isWalking", moveInput !=0);
         
        if (isGrounded)
        {
            Vector2 moveDirection = new Vector2(moveInput * speed, rb.velocity.y);
            rb.velocity = moveDirection;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound(jumpSound);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void PlaySound(AudioClip soundClip)
    {
        audioSource.PlayOneShot(soundClip);
    }
}