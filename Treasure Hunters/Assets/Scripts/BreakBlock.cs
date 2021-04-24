using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakBlock : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject player;
    public GameManager gameManager;

    const float minDistance = 3.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameManager.pickaxeUses > 0)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, player.transform.position) < minDistance)
            {
                Vector3Int gridPos = tilemap.WorldToCell(mousePos);
                TileBase clicked = tilemap.GetTile(gridPos);
                if (clicked != null)
                {
                    tilemap.SetTile(gridPos, null);
                    gameManager.pickaxeUses -= 1;
                }
            }
        }
    }
}
