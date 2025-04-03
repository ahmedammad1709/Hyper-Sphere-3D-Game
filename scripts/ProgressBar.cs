using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;
    public float levelDuration = 10f; // Time required to fill bar
    private float elapsedTime = 0f;
    private bool levelComplete = false;
    private bool isProgressing = true;
    public TextMeshProUGUI gameoverText;
    public GameObject player;
    public int currentLevel;
    public AudioSource levelCompletedAudio;

    void Start()
    {
        levelCompletedAudio.Stop();
        progressBar.value = 0;
        gameoverText.text = "";
    }

    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (!levelComplete && isProgressing)
        {
            if (player != null) // Check if player exists
            {
                elapsedTime += Time.deltaTime;
                progressBar.value = elapsedTime / levelDuration;

                if (progressBar.value >= 1)
                {
                    LevelCompleted();
                }
            }
            else
            {
                StopProgress();
            }
        }
    }

    void StopProgress()
    {
        isProgressing = false;
        gameoverText.text = "Game Over!";
        Debug.Log("Progress Stopped - Player Lost");
        FindFirstObjectByType<overallGameManager>().gameEnd(0);
    }

    void LevelCompleted()
    {
        levelComplete = true;
        isProgressing = false; // Stop progress bar
        levelCompletedAudio.Play();
        UnlockNextLevel(currentLevel);
        Debug.Log("Level Completed!");
        gameoverText.text = "Level Completed!";
        FindFirstObjectByType<overallGameManager>().gameEnd(1); // Pass 1 for level completion
    }

    public void UnlockNextLevel(int currentMission)
    {
        int unlockedMission = PlayerPrefs.GetInt("currentlevel", 1);
        if (unlockedMission < currentMission + 1)
        {
            PlayerPrefs.SetInt("currentlevel", currentMission + 1);
            PlayerPrefs.Save();
        }
    }
}
