using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    Rigidbody2D rb;
    Animator anim;

    bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal"); 

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (move != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(move) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        bool isWalking = Mathf.Abs(move) > 0.1f;
        anim.SetBool("isWalking", isWalking);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetTrigger("isJumping");
            isGrounded = false; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;

            bool isWalking = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
            anim.SetBool("isWalking", isWalking);
        }
    }
}
