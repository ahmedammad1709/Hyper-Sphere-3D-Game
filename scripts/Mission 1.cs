using TMPro;
using UnityEngine;


public class Mission1 : MonoBehaviour
{
    public Timer timer;
    public AudioSource MissionCompleted;
    public TextMeshProUGUI Text;
  
    private bool missionCompleted = false;


    private void Start()
    {
      
        MissionCompleted.Stop();
        Text.text = "Game Over!";
    }
    void Update()
    {
        if (!missionCompleted && timer.elapsedTime >= 20f)
        {
            MissionCompleted.Play();
          
            FindFirstObjectByType<overallGameManager>().gameEnd(20);
            Text.text = "Mission Completed!";
            missionCompleted = true;
            
            UnlockNextMission(1);
        }
    }

    public static void UnlockNextMission(int currentMission)
    {
        int unlockedMission = PlayerPrefs.GetInt("missionAt", 1);
        if (unlockedMission < currentMission + 1)
        {
            PlayerPrefs.SetInt("missionAt", currentMission + 1);
            PlayerPrefs.Save();
        }
    }

}
