using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    [Range(5.0f, 10.0f)] public float speed = 5.0f;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask enemyMask;

    float jumpGravityScale;
    float fallGravityScale;
    float jumpForce;
    float invincibilityTime;
    float dir;
    float impulseForce;
    float impulseDir;

    bool doJump;
    bool isInvincible;
    bool doDamageBounce;
    bool didImpulse;

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    SpriteRenderer sprite;

    const float epsilon = 0.000001f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        jumpGravityScale = rb.gravityScale;
        fallGravityScale = jumpGravityScale * 1.25f;
        jumpForce = 22.0f;
        invincibilityTime = 2.5f;
        impulseForce = 10.0f;

        doJump = false;        
        isInvincible = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!doJump && IsGrounded() && Input.GetButtonDown("Jump"))
            doJump = true;
    }

    void FixedUpdate()
    {
        if (!doDamageBounce)
        {
            dir = speed * Input.GetAxisRaw("Horizontal");
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
        else if (!didImpulse)
        {
            didImpulse = true;
            print("Doing the impulse force thing");
            rb.AddForce(new Vector2(impulseForce * impulseDir, impulseForce), ForceMode2D.Impulse);
            StartCoroutine("PlayerBlink");
            StartCoroutine("PlayerFreeze");
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,
          Vector2.down, boxCollider.bounds.extents.y, groundMask | enemyMask);
        return hit.collider != null;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!isInvincible && other.transform.CompareTag("Enemy"))
        {
            doDamageBounce = true;
            impulseDir = transform.position.x - other.transform.position.x > 0 ? 1 : -1;
            gameManager.TakeDamage(other.gameObject.GetComponent<IEnemy>().DealDamage());
            StartCoroutine("DamageBoost");
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (!isInvincible && other.transform.CompareTag("Enemy"))
        {
            doDamageBounce = true;
            impulseDir = transform.position.x - other.transform.position.x > 0 ? 1 : -1;
            gameManager.TakeDamage(other.gameObject.GetComponent<IEnemy>().DealDamage());
            StartCoroutine("DamageBoost");
        }
    }

    IEnumerator DamageBoost()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
        didImpulse = false;
    }

    IEnumerator PlayerFreeze()
    {
        yield return new WaitForSeconds(0.4f);
        doDamageBounce = false;
    }

    IEnumerator PlayerBlink()
    {
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.25f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.25f);

        sprite.enabled = false;
        yield return new WaitForSeconds(0.25f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.25f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.25f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.25f);

        sprite.enabled = false;
        yield return new WaitForSeconds(0.25f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
    }
}
