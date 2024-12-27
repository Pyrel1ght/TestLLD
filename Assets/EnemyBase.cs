using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    protected IAttack _attack;
    [SerializeField] protected RaycastHit2D Groundhit, Wallhit;
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected bool facingRight = true;

    public void SetAttack(IAttack attack)
    {
        _attack = attack;
    }
    public void Damage()
    {
        Destroy(gameObject);

    }
    protected virtual void FixedUpdate()
    {
        if (facingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

        }
    }
}
