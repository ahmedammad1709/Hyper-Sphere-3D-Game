using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionSelectionManager : MonoBehaviour
{
    public Button[] missionButtons;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI coinsText;

    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt(": ", 0);
        coinsText.text = ": " + totalCoins;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = ": " + highScore;

        int missionAt = PlayerPrefs.GetInt("missionAt", 1); // Default to 1 (only Mission 1 unlocked)
       
        for (int i = 0; i < missionButtons.Length; i++)
        {
            if (i + 1 > missionAt)
                missionButtons[i].interactable = false;  // Lock missions
            else
                missionButtons[i].interactable = true;   
        }
    }
}
