using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mission4Score : MonoBehaviour
{
    private int score;
    [SerializeField]private TextMeshProUGUI endText;
    public AudioSource audio;
    private bool missionCompleted = false;
   
    private void Start()
    {
       
        endText.text = "Game Over!";
        audio.Stop();
    }

    private void Update()
    {
        score = FindFirstObjectByType<Score>().score;
        if (!missionCompleted && score >= 1000)
        {
            checkScore();
        }
    }



    private void checkScore()
    {
        missionCompleted = true;
        audio.Play();
      
        Debug.Log("Play audio..Mission Completed!");
        endText.text = "Mission Completed!";
        int coinsPlus = 100;
        FindFirstObjectByType<overallGameManager>().gameEnd(coinsPlus);

        Mission1.UnlockNextMission(4);
    }
}
