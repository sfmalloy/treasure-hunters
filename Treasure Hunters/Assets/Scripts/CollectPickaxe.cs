using UnityEngine;

public class CollectPickaxe : MonoBehaviour
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
            gameManager.pickaxeUses += value;
            Destroy(gameObject);
        }
    }
}
