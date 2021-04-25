using UnityEngine;

public class LizardEnemy : MonoBehaviour, IEnemy
{
    public float distance;
    public float speed;

    Rigidbody2D rb;
    Vector2 startPos;
    float dir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;
        dir = -1.0f;
    }

    void Update()
    {
        AttackMovement();
    }

    public void AttackMovement()
    {
        rb.velocity = new Vector2(speed * dir, 0);
        if (Vector2.Distance(rb.position, startPos) >= distance)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            startPos = rb.position;
            dir *= -1;
        }
    }

    public int DealDamage()
    {
        return 15;
    }
}
