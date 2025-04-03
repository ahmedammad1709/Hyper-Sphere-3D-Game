using TMPro;
using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI CoinsText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject gameOverWindow;

    

    public void GameOver(int score, int coins)
    {
        gameOverWindow.SetActive(true);
        ScoreText.text = "Score : " + score;
        CoinsText.text = "Coins Collected : "+ coins;

        int totalCoins = PlayerPrefs.GetInt(": ", 0);
        totalCoins += coins;
        PlayerPrefs.SetInt(": ", totalCoins);
        PlayerPrefs.Save();
        Debug.Log("Total coins saved : "+ totalCoins);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = ": " + highScore;
    }

}
