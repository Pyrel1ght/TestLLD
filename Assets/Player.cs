using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float speed,jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField]GameObject GameOverScreen;
    Rigidbody2D rb;

    
    private void Awake()
    {
        Time.timeScale = 1f;
        rb = gameObject.GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if ( Input.GetKey(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            Debug.Log("jump");
            isGrounded = false;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.gameObject.tag == "ground")
            {
                isGrounded = true;
        }
        if (collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().Damage();
            Debug.Log("Player attacked");
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * (jumpForce * 0.3f), ForceMode2D.Impulse);
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            collision.gameObject.GetComponent<IInteractable>().Interact();
        }
        Debug.Log("touched");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
    public void Damage()
    {
        GameOverScreen.SetActive(true);

        Time.timeScale = 0f;
    }
}
