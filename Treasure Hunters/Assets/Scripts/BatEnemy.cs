using UnityEngine;
using System.Collections;

public class BatEnemy : MonoBehaviour, IEnemy
{
    public GameObject player;

    Rigidbody2D rb;
    Rigidbody2D playerRb;

    Vector2 startPos;
    Vector2 endPos;

    Animator animator;
    SpriteRenderer spriteRenderer;
    Sprite initSprite;

    bool attacking;
    bool wait;

    float arcTime;
    float halfPeriod;
    float height;
    float sign;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
        
        attacking = false;
        startPos = rb.position;

        halfPeriod = 2.0f;
        height = 3.0f;
        sign = 1.0f;
        animator = GetComponent<Animator>();
        animator.enabled = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
        initSprite = spriteRenderer.sprite;
    }

    void FixedUpdate()
    {
        if (!wait && (attacking || (Vector2.Distance(playerRb.position, rb.position) < 5)))
        {
            if (!attacking)
            {
                arcTime = 0.0f;
                attacking = true;
            }
            else
            {
                animator.enabled = true;
                AttackMovement();
            }
        }
    }

    public void AttackMovement()
    {
        if (arcTime < halfPeriod)
        {
            arcTime += 3.0f * Time.fixedDeltaTime;
            rb.position = startPos + new Vector2(sign * 2.0f * arcTime, -height * Mathf.Sin(Mathf.PI * arcTime / halfPeriod));
        }
        else
        {
            sign *= -1;
            arcTime = 0.0f;
            rb.position = new Vector2(rb.position.x, startPos.y);
            startPos = rb.position;
            StartCoroutine("Cooldown");
        }
    }

    public int DealDamage()
    {
        return 15;
    }

    IEnumerator Cooldown()
    {
        wait = true;
        animator.enabled = false;
        spriteRenderer.sprite = initSprite;
        yield return new WaitForSeconds(3.0f);
        attacking = false;
        wait = false;
    }
}
