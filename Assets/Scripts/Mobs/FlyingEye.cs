using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    public LayerMask playerLayers;
    public Player player;
    public Rigidbody2D rb;
    public Animator animator;
    public FlyingEyeMovement movement;
    public FlyingEyeCombat combat;
    public Transform attackPoint;
    public HealthBar healthBar;
    public DamageNumber damageNumber;
    Transform playerPos;
    
    //Stats
    public float agroRadius = 100f;

    public int expDrop = 10;
    public int maxHealth = 60;
    public int attackDamage = 15;
    public float attackRange = 1f;
    public float attackRate = 1f;
    public float moveSpeed = 5f;

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

    void Hit()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player>().TakeDamage(attackDamage);
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
        animator.SetBool("Dead", true);
        healthBar.disableCanvas();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<FlyingEyeMovement>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        this.enabled = false;
    }

    void DropExp()
    {
        player.GetDrop(expDrop);
    }


}
