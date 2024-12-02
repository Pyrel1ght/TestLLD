using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]protected RaycastHit2D Groundhit, Wallhit;
    [SerializeField]float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField]protected LayerMask groundMask;
    [SerializeField]protected Transform groundCheck;
    [SerializeField]protected bool facingRight = true;


    // Update is called once per frame
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
    private void FixedUpdate()
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
    public void Damage()
    {
        Destroy(gameObject);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>()!=null && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<IDamageable>().Damage();
            Debug.Log("Enemy attacked");
        }
    }
}
