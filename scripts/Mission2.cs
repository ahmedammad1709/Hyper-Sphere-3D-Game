using TMPro;
using UnityEngine;

public class Mission2 : MonoBehaviour
{
    public AudioSource missioncompleteAudio;
    public TextMeshProUGUI gameOvertext;
    public TextMeshProUGUI obstacleText;
    int counter;
    private GameObject player;
    private int totalObstacles = 20;
    bool missionCompleted =false;
  

    private void Start()
    {
        
        obstacleText.text = "Obsatcle : 0/" + totalObstacles;
        missioncompleteAudio.Stop();
        gameOvertext.text = "Game Over!";
    }
    private void LateUpdate()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            counter = FindFirstObjectByType<player>().counter;
        }
    }
    private void Update()
    {
        if (!missionCompleted)
        {
            obstacleText.text = "Obstacle : " + counter + "/" + totalObstacles;
            if (counter >= totalObstacles)
            {
                gameOvertext.text = "Mission Completed!";
                missioncompleteAudio.Play();
              
                FindFirstObjectByType<overallGameManager>().gameEnd(40);
                missionCompleted = true;
                Mission1.UnlockNextMission(2);
            }
        }
        
       
    }

}