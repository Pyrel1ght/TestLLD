using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAttack
{
    IDamageable collision;
    public MeleeAttack(IDamageable collision)
    {
        this.collision = collision; 
    }
    public void Attack()
    {
        collision.Damage();
        Debug.Log("Melee attack");
    }
}
