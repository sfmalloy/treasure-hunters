using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(5.0f, 10.0f)]
    public float speed = 5.0f;
    [SerializeField]
    private LayerMask groundMask;

    float jumpGravityScale;
    float fallGravityScale;
    float jumpForce;
    float distToGround;

    bool touchingGround, doJump;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    const float epsilon = 0.000001f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpGravityScale = rb.gravityScale;
        fallGravityScale = jumpGravityScale * 1.25f;
        jumpForce = 22.0f;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!doJump && IsGrounded() && Input.GetButtonDown("Jump"))
            doJump = true;
    }

    void FixedUpdate()
    {
        float dir = speed * Input.GetAxisRaw("Horizontal");
        float newX = 0;
        if (Input.GetAxisRaw("Horizontal") != 0)
            newX = dir;
        else if (rb.velocity.magnitude > epsilon)
            newX = rb.velocity.x * 0.85f;

        rb.velocity = new Vector2(newX, rb.velocity.y);
        if (doJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            doJump = false;
        }
        if (rb.velocity.y < epsilon)
            rb.gravityScale = jumpGravityScale;
        else
            rb.gravityScale = fallGravityScale;
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,
          Vector2.down, boxCollider.bounds.extents.y + 0.1f, groundMask);
        return hit.collider != null;
    }
}
