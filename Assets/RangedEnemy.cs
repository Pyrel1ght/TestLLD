using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] float timer, arrowSpeed;
    [SerializeField] GameObject arrow,child;
    [SerializeField]float tempTimer;
    private void Update()
    {
        Groundhit = Physics2D.Raycast(groundCheck.position, -transform.up, 0.2f, groundMask);
        Wallhit = Physics2D.Raycast(groundCheck.position, transform.right, 0.2f, groundMask);
        if (Groundhit.collider == null || Wallhit.collider != null)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }
        if (tempTimer >= timer) {
            Attack();
            tempTimer = 0;
        } else
        {
            tempTimer += Time.deltaTime;
        }
    }
    void Attack()
    {
        child = Instantiate(arrow,transform.position,Quaternion.identity,null);
        if (facingRight)
        {
            child.GetComponent<Arrow>().Speed = arrowSpeed;
        }
        else
        {
            child.GetComponent<Arrow>().Speed = -arrowSpeed;
        }
    }
}
