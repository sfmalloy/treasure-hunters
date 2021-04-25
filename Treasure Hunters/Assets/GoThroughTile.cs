using UnityEngine;
using System.Collections;

public class GoThroughTile : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine("DisableTrigger");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<CompositeCollider2D>().isTrigger = true;    
    }

    IEnumerator DisableTrigger()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<CompositeCollider2D>().isTrigger = false;
    }
}
