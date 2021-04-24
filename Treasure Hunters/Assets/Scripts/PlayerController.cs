using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(5.0f, 10.0f)]
    public float speed = 5.0f;

    bool touchingGround, doJump;
    Rigidbody2D rb;

    const float epsilon = 0.000001f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        float dir = speed * Input.GetAxisRaw("Horizontal");
        float newX = 0;
        if (Input.GetAxisRaw("Horizontal") != 0)
            newX = dir;
        else if (rb.velocity.magnitude > epsilon)
            newX = rb.velocity.x * 0.9f;

        rb.velocity = new Vector2(newX, rb.velocity.y);
        if (Input.GetButton("Jump") && touchingGround && rb.velocity.y == 0)
        {
            doJump = false;
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        touchingGround = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        touchingGround = false;
    }
}
