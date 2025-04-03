using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float elapsedTime = 0f; 
    private bool timerRunning = false; 

    [SerializeField] private TextMeshProUGUI timerText;

    void Start()
    {
        timerRunning = true; 
    }

   
    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime; // Increase time based on game time
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Convert time to minutes
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // Get remaining seconds
        timerText.text = string.Format("Time Elapsed : {0:00}:{1:00}", minutes, seconds); // Format text
    }

    public void StopTimer()
    {
        timerRunning = false; // Stop the timer
    }
}
