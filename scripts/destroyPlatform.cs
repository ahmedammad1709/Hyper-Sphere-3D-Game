using UnityEngine;

public class destroyPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy the parent platform when the player crosses the destroy trigger
            Destroy(transform.parent.gameObject);
        }
    }
}
