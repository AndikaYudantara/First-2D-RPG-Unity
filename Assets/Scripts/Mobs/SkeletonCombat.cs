using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCombat : MonoBehaviour
{
    public Animator animator;
    public Skeleton skeleton;

    float nextAttackTime = 0f;
    
    public void Attack(float attackRate)
    {

        if (Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            animator.SetTrigger("Attack1");
            skeleton.moveSpeed *= 0.4f;
        }
    }

    
}
