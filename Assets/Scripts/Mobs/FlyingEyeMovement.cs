using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeMovement : MonoBehaviour
{
    public FlyingEye monster;
    public Rigidbody2D rb;
    
    Transform player;
    bool faceRight = true;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Move(float moveSpeed)
    {
        if (rb.position.x > player.position.x && faceRight == true)
        {
            flip();
            faceRight = false;
        }
        else if (rb.position.x < player.position.x && faceRight == false)
        {
            flip();
            faceRight = true;
        }
        Vector3 dir = (player.position - this.transform.position).normalized;
        //this.transform.position = dir * Time.deltaTime;
        transform.position = transform.position + dir * moveSpeed * Time.deltaTime;
    }

    public void revertMoveSpeed()
    {
        monster.moveSpeed = 10;
    }

    void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
  
}
