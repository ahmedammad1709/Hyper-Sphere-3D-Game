using TMPro;
using UnityEngine;

public class Mission5 : MonoBehaviour
{
    public AudioSource missioncompleteAudio;
    public TextMeshProUGUI gameOvertext;
    public TextMeshProUGUI obstacleText;
    int counter;
    private GameObject player;
    private int totalObstacle = 100;
    bool missionCompleted = false;


    private void Start()
    {
      
        obstacleText.text = "Obsatcle : 0/" + totalObstacle;
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

            obstacleText.text = "Obstacle : " + counter + "/" + totalObstacle;
            if (counter >= totalObstacle)
            {
                gameOvertext.text = "Mission Completed!";
                missioncompleteAudio.Play();
             
                FindFirstObjectByType<overallGameManager>().gameEnd(120);
                missionCompleted = true;

                Mission1.UnlockNextMission(5);
            }
        }


    }

}