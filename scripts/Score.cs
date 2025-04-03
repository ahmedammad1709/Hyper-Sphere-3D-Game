using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    public int score = 0;
    private float scoreMultiplier =10 ;
    float distance;
   
    //public GameObject player;
    bool isGameOver = false;
    bool startScore = false;

    private void Start()
    {
        startScore = true;
       
    }

    private void Update()
    {   if (startScore)
        {
            if (!isGameOver)
            {
                distance += (Time.deltaTime * scoreMultiplier);
                score = Mathf.FloorToInt(distance);
                scoreText.text = "Score : " + score;
                checkHighScore();
            }
        }
    }

    void checkHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void BoostScore(bool isBoosted)
    {
        scoreMultiplier = isBoosted ? 20 : 10;
    }
    public void StopScore()
    {
        startScore=false;
    }

}
