using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class Disintegratable : MonoBehaviour
{
    public GameObject player;

    bool gone = false;
    Vector2 point;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ContactPoint2D contact = other.contacts[0];
            point = contact.point;

            Vector3Int gridPos = GetComponent<Tilemap>().WorldToCell(point);
            gridPos = new Vector3Int(gridPos.x, gridPos.y, gridPos.z);
            TileBase tile = GetComponent<Tilemap>().GetTile(gridPos);

            if (tile != null)
                StartCoroutine(Delay(gridPos, tile));
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ContactPoint2D contact = other.contacts[0];
            point = contact.point;

            Vector3Int gridPos = GetComponent<Tilemap>().WorldToCell(point);
            gridPos = new Vector3Int(gridPos.x, gridPos.y, gridPos.z);
            TileBase tile = GetComponent<Tilemap>().GetTile(gridPos);

            if (tile != null)
                StartCoroutine(Delay(gridPos, tile));
        }
    }

    IEnumerator Delay(Vector3Int gridPos, TileBase tile)
    {
        // StartCoroutine("DelayCoroutine");
        yield return new WaitForSeconds(0.4f);
        GetComponent<Tilemap>().SetTile(gridPos, null);
        // Thread.Sleep(3000);
        yield return new WaitForSeconds(3.0f);
        GetComponent<Tilemap>().SetTile(gridPos, tile);
    }
}
