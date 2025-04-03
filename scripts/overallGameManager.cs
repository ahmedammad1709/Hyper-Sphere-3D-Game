using UnityEngine;
using UnityEngine.UI;

public class overallGameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverWindow;

    public AudioSource gameOverAudioSource;
    public AudioSource CoinAudio;
    public AudioSource ScoreBoosterAudio;

    public GameObject scoreBooster;
    public Button homeButton;
    public Button nextButton;
    public Button restartButton;



    private void Start()
    {
        gameOverWindow.SetActive(false);
        scoreBooster.SetActive(false);
        gameOverAudioSource.Stop();
        CoinAudio.Stop();
        ScoreBoosterAudio.Stop();
        homeButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

    }

    public void playGameOverAudio()
    {
        gameOverAudioSource.Play();
    }
    public void playCoinAudio()
    {
        CoinAudio.Play();
    }

    public void playScoreBoosterAudio()
    {
        ScoreBoosterAudio.Play();
    }

    public void gameEnd(int c)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player)
        {
            Destroy(player);
        }
        gameOverWindow.SetActive(true);
        Timer timer = FindFirstObjectByType<Timer>();
        if(timer != null)
        {
            timer.StopTimer();
        }
        FindFirstObjectByType<Score>().StopScore();
        int scoreText = FindFirstObjectByType<Score>().score;
        int coinsText = FindFirstObjectByType<Coins>().playerCoins;
        //float timeText = FindFirstObjectByType<Timer>().elapsedTime;
        c = coinsText + c;
        FindFirstObjectByType<GameOverWindow>().GameOver(scoreText, c);
        homeButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        Debug.Log("Game Over! Playing motivational message.");
    }

    public void ScoreBoosterImageTrue()
    {
        scoreBooster.SetActive(true);
    }

    public void ScoreBoosterImageFalse()
    {
        scoreBooster.SetActive(false);
    }

}
