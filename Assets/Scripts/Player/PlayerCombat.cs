using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Player player;
    public PlayerMovement movement;
    public Animator animator;
    

    float nextAttackTime = 0f;

    public void Attack(float attackRate)
    {
        if (movement.onGround && Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextAttackTime = Time.time + 1f / attackRate;
                animator.SetTrigger("LightAttack");
                player.moveSpeed *= 0.2f;
            }
            else if (Input.GetMouseButtonUp(1))
            {
                nextAttackTime = Time.time + 1f / (attackRate - 0.5f);
                animator.SetTrigger("HeavyAttack");
                player.moveSpeed *= 0.01f;
            }
        }
    }
}
