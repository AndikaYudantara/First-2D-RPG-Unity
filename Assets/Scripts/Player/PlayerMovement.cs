using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    public float defaultMoveSpeed;

    public bool onGround = true;
    
    float horizontalMove = 0f;
    float verticalVelocity = 0f;
    bool jump = false;
    //bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y != 0)
        {
            verticalVelocity = rb.velocity.y;
            if (verticalVelocity < -12f)
            {
                onGround = false;
            }
        }

        animator.SetBool("OnGround", onGround);
        animator.SetFloat("VerticalVelocity", verticalVelocity);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;    
            onGround = false;
            revertMoveSpeed();
        }

        /*if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }*/
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    public void Move(float moveSpeed)
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
    public void revertMoveSpeed()
    {
        player.moveSpeed = defaultMoveSpeed;
    }
}
