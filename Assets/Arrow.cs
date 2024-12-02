using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyArrow());
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<IDamageable>().Damage();
        }
        Destroy(gameObject);
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    private IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
