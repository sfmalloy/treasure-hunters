using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    public GameObject player;
    GameManager gameManager;

    const float minDistance = 3.0f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown()
    {
        if (gameManager.pickaxeUses > 0 
            && Vector2.Distance(player.transform.position, transform.position) < minDistance)
        {
            Destroy(gameObject);
            gameManager.pickaxeUses -= 1;
        }
    }
}
