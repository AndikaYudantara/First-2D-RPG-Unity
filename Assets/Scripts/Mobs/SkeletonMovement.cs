using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public Skeleton skeleton;
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;
    Transform player;

    float horizontalMove = 0f;
    float target;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }

    public void Move(float moveSpeed)
    {
        if (rb.position.x > player.position.x)
        {
            target = -1f;
        } else if (rb.position.x < player.position.x) {
            target = 1f;
        }
        horizontalMove = target * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void revertMoveSpeed()
    {
        skeleton.moveSpeed = 20;
    }
  
}
