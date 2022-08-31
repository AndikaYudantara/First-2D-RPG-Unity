using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCombat : MonoBehaviour
{
    public Animator animator;
    public King king;

    float nextAttackTime = 0f;
    
    public void Attack(float attackRate)
    {

        if (Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            int attackType = Random.Range(1, 4);
            if (attackType == 1)
            {
                animator.SetTrigger("Attack1");
                king.moveSpeed *= 0.4f;
            } else if (attackType == 2)
            {
                animator.SetTrigger("Attack2");
                king.moveSpeed *= 0.1f;
            } else if (attackType == 3)
            {
                animator.SetTrigger("Attack3");
                king.moveSpeed *= 0.2f;
            }

            
        }
    }

    
}
