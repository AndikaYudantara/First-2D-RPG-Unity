using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    public LayerMask playerLayers;
    public Player player;
    public Rigidbody2D rb;
    public Animator animator;
    public KingMovement movement;
    public KingCombat combat;
    public Transform attackPoint;
    public HealthBar healthBar;
    public DamageNumber damageNumber;
    Transform playerPos;
    
    //Stats
    public float agroRadius = 60f;

    public int expDrop = 100;
    public int maxHealth = 100;
    public int attackDamage = 10;
    public float attackRange = 1f;
    public float attackRate = 1f;
    public float moveSpeed = 20f;

    int currentHealth;
    float distanceToPlayer;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    void Update()
    {
        Seek();
    }

  /*  void Spawn()
    {

    }

    void Wander()
    {

    }*/

    void Seek()
    {
        Collider2D[] seePlayer = Physics2D.OverlapCircleAll(rb.position, agroRadius, playerLayers);
        foreach (Collider2D player in seePlayer)
        {
            Chase();
        }
    }

    void Chase()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        distanceToPlayer = Vector2.Distance(rb.position, playerPos.position);
        movement.Move(moveSpeed);
        if (distanceToPlayer <= attackRange+1)
        {
            Attack();
        }
    }


    void Attack()
    {
        combat.Attack(attackRate);
    }

    void Hit(int attackType)
    {
        
        if (attackType == 1)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                player.GetComponent<Player>().TakeDamage(attackDamage);
            }
        }
        else if (attackType == 2)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange + 2.5f, playerLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                player.GetComponent<Player>().TakeDamage(attackDamage*150/100);
            }
        }
        else if (attackType == 3)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange + 2.5f, playerLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                player.GetComponent<Player>().TakeDamage(attackDamage*120/100);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        damageNumber.showDamage(damage);
        animator.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DropExp();
        animator.SetBool("Die", true);
        healthBar.disableCanvas();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<KingMovement>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        this.enabled = false;
    }

    void DropExp()
    {
        player.GetDrop(expDrop);
    }


}
