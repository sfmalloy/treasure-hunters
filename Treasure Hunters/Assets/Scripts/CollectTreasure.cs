using UnityEngine;

public class CollectTreasure : MonoBehaviour
{
    public GameManager gameManager;
    public int value;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("fnasjkdldfnlj");
        if (other.CompareTag("Player"))
        {
            gameManager.score += value;
            Destroy(gameObject);
        }
    }
}
