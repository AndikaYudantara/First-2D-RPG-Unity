using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeCombat : MonoBehaviour
{
    public Animator animator;
    public FlyingEye monster;

    float nextAttackTime = 0f;
    
    public void Attack(float attackRate)
    {

        if (Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            animator.SetTrigger("Attack1");
        }
    }

    
}
