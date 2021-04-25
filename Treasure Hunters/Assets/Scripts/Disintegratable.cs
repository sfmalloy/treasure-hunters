using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class Disintegratable : MonoBehaviour
{
    public GameObject player;

    bool gone = false;
    Vector2 point;

    void FixedUpdate()
    {
        Vector3Int gridPos = GetComponent<Tilemap>().WorldToCell(point);
        gridPos = new Vector3Int(gridPos.x, gridPos.y-1, gridPos.z);
        // TileBase tile = GetComponent<Tilemap>().GetTile(gridPos);
        StartCoroutine(Delay(gridPos));
        // GetComponent<Tilemap>().SetTile(gridPos, null);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ContactPoint2D contact = other.contacts[0];
            point = contact.point;
        }
    }

    IEnumerator Delay(Vector3Int gridPos)
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Tilemap>().SetTile(gridPos, null);
    }
}
