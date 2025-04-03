using TMPro;
using UnityEngine;


public class Mission6 : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI endText;
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
        if (!missionCompleted && score >= 2000)
        {
            checkScore();
        }
    }



    private void checkScore()
    {
        
        audio.Play();
        Debug.Log("Play audio..Mission Completed!");
        endText.text = "Mission Completed!";

        int coinsPlus = 300;

        FindFirstObjectByType<overallGameManager>().gameEnd(coinsPlus);
        missionCompleted = true;

        Mission1.UnlockNextMission(6);
    }
}
