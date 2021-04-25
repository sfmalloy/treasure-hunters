using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float xThreshold = 2.5f;

    Rigidbody2D rb;
    Rigidbody2D playerRb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
        rb.position = new Vector2(playerRb.position.x, playerRb.position.y + 1.0f);
    }

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2();
        if (Mathf.Abs(playerRb.position.x - rb.position.x) > xThreshold)
            velocity.x = player.GetComponent<Rigidbody2D>().velocity.x;
        else
            velocity.x = 0.0f;
        
        rb.velocity = velocity;
        rb.position = Vector2.Lerp(rb.position, new Vector2(rb.position.x, playerRb.position.y + 1.0f), 10.0f * Time.fixedDeltaTime);
    }
}
