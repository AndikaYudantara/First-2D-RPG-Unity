using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Rigidbody2D rb;
    public Animator animator;
    public PlayerMovement movement;
    public PlayerCombat combat;
    public Transform attackPoint;
    public HealthBar healthBar;
    public DamageNumber damageNumber;

    public int maxHealth = 100;
    public float attackRange = 1f;
    public float attackRate = 1f;
    public float moveSpeed = 50f;
    public int attackDamage = 10;
    public bool dead = false;

    int currentExp = 0;
    int maxExp = 10;
    int level = 1;
    int currentHealth;
    

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        movement.defaultMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        movement.Move(moveSpeed);
    }

    void Attack()
    {
        combat.Attack(attackRate);
    }

    void Hit(int attackType)
    {
        if (attackType == 1)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Skeleton>().TakeDamage(attackDamage);
            }
        }
        else if (attackType == 2)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange + 2.5f, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Skeleton>().TakeDamage(attackDamage*150/100);
            }
        }
    }

    public void GetDrop(int exp)
    {
        currentExp += exp;
        while (currentExp > maxExp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentExp = currentExp - maxExp;
        maxExp += maxExp * 1 / 2;
        level += 1;
        StatusUp();
    }

    void StatusUp()
    {
        maxHealth *= 2;
        attackDamage += attackDamage * 1 / 5;
        attackRate += 0.1f;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        damageNumber.showDamage(damage);
        animator.SetTrigger("Hit");
        if (movement.onGround)
        {
            moveSpeed *= 0.1f;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("Die", true);
        healthBar.disableCanvas();
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        this.enabled = false;
        
    }
}
