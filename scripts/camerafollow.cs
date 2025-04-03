using UnityEngine;

public class camerafollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Vector3 offset;

    void Start()
    {
        FindPlayer();  // 🔹 Instead of directly setting, use a method
    }

    void LateUpdate()
    {
        if (player == null)
        {
            FindPlayer();  // 🔹 Keep checking if player is missing
        }

        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }

    void FindPlayer()
    {
        GameObject foundPlayer = GameObject.FindWithTag("Player");
        if (foundPlayer)
        {
            player = foundPlayer.transform;
            Debug.Log("Camera assigned to player: " + player.name);
        }
    }
}
