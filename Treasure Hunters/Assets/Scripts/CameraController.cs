using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb;
    Rigidbody2D playerRb;

    const float xThreshold = 3.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2();
        if (Mathf.Abs(playerRb.position.x - rb.position.x) > xThreshold)
            velocity.x = player.GetComponent<Rigidbody2D>().velocity.x;
        else
            velocity.x = 0.0f;
        
        rb.velocity = velocity;
        rb.position = Vector2.Lerp(rb.position, new Vector2(rb.position.x, playerRb.position.y + 2.0f), 10.0f * Time.fixedDeltaTime);
    }
}
