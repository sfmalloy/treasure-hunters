using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rb;

    const float threshold = 2.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > threshold)
            rb.velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 0);
        else
            rb.velocity = Vector2.zero;
    }
}
