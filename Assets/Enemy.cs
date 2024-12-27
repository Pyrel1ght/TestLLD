using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{

    void Update()
    {
        Groundhit = Physics2D.Raycast(groundCheck.position,-transform.up,0.2f,groundMask);
        Wallhit = Physics2D.Raycast(groundCheck.position, transform.right, 0.2f, groundMask);
        if (Groundhit.collider == null || Wallhit.collider != null)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable collisionDamage = collision.gameObject.GetComponent<IDamageable>();
        
        if (collisionDamage!=null && collision.gameObject.tag == "Player")
        {
            MeleeAttack attack = new MeleeAttack(collisionDamage);
            SetAttack(attack);
            _attack.Attack();
            Debug.Log("Enemy attacked");
        }
        
    }
}
