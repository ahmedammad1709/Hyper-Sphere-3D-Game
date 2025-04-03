using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject[] platforms;
    public float spawnDistance = 10f;
    private int randomIndex;

    [SerializeField]
    private Vector3 ofset;

    public void spawnPlatform(Vector3 position)
    {

        randomIndex = Random.Range(0, platforms.Length);
        Instantiate(platforms[randomIndex], position + ofset, Quaternion.identity);
    }


}
