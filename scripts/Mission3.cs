using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Mission3 : MonoBehaviour
{
    public Timer timer;
    public AudioSource MissionCompleted;
    public TextMeshProUGUI text;
 
    private bool missionCompleted = false;


    private void Start()
    {
        
        MissionCompleted.Stop();
        text.text = "Game Over!";
    }
    void Update()
    {
        if (timer.elapsedTime >= 60f && !missionCompleted)
        {
            MissionCompleted.Play();
        
            FindFirstObjectByType<overallGameManager>().gameEnd(80);
            text.text = "Mission Completed!";
            missionCompleted = true;

            Mission1.UnlockNextMission(3);
        }
       
    }

   
}
