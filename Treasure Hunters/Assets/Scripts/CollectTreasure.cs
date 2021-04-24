using UnityEngine;

public class CollectTreasure : MonoBehaviour
{
    GameManager gameManager;
    public int value;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.score += value;
            Destroy(gameObject);
        }
    }
}
