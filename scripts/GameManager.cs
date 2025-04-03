using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This script is for Selecting the player 

    public GameObject[] player;
    private GameObject Spawnedplayer;

    void Start()
    {
        int SelectedPlayerIndex = PlayerPrefs.GetInt("SelectedPlayer", 0);
        SpawnPlayer(SelectedPlayerIndex);
    }

    private void SpawnPlayer(int index)
    {
        Vector3 spawnPosition = new Vector3(-1, -5, -77);
        Spawnedplayer = Instantiate(player[index], spawnPosition, Quaternion.identity);
    }


}
