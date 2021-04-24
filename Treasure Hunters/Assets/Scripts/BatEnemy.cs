using UnityEngine;
using System.Collections;

public class BatEnemy : MonoBehaviour, IEnemy
{
    public GameObject player;

    Rigidbody2D rb;
    Rigidbody2D playerRb;

    Vector2 startPos;

    bool attacking;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
        attacking = false;
        startPos = rb.position;
    }

    void Update()
    {
        if (!attacking && Vector2.Distance(startPos, playerRb.position) < 5)
        {
            AttackMovement();
        }
    }

    public void IdleMovement()
    {  }

    public void AttackMovement()
    {
        attacking = true;
        print(playerRb.position - startPos);
        rb.velocity = playerRb.position - startPos / 3.0f;
    }

    public int DealDamage()
    {
        return 15;
    }

    IEnumerator Cooldown()
    {
        Vector2 velocity = startPos - rb.position / 3.0f;
        while (rb.position != startPos)
            rb.velocity = velocity;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(3.0f);
        attacking = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine("Cooldown");
        }
    }
}
