using System;
using UnityEngine;

public class levelGen : MonoBehaviour
{
    private platformSpawner spawnerScript;

    private void Start()
    {
        spawnerScript = FindFirstObjectByType<platformSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("level changed");
            spawnerScript.spawnPlatform(transform.position);

        }
    }
}
