using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destination;
    public GameObject mainCamera;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().position = destination.transform.position;
            mainCamera.GetComponent<Rigidbody2D>().position = destination.transform.position;
        }
    }
}
