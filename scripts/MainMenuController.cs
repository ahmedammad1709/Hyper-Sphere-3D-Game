using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        int totalCoins = PlayerPrefs.GetInt(": ", 0);
        totalCoinsText.text = ": " + totalCoins;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = ": " + highScore;
        Debug.Log("high score : " + highScore);
    }

  
}
