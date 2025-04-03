using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    public GameObject[] players;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private GameObject unlockPlayerWindow;
    [SerializeField] private GameObject backButton1;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private TextMeshProUGUI unlockPlayerWindowText;
    [SerializeField] private Button[] balls;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject unlockImage;
    [SerializeField] public GameObject[] ballsText; //Buy for $30 eg
    [SerializeField] private GameObject[] playerExtraText; //Text when the player will unlock

    private int coinsRequiredForUnlock;
    private int ballIndex;

    private int totalCoins;
    private int SelectedPlayerIndex = 0;

    private void Start()
    {
        backButton1.SetActive(true);
        nextButton.SetActive(true);
        unlockPlayerWindow.SetActive(false);
        lockImage.SetActive(false);
        unlockImage.SetActive(false);
        totalCoins = PlayerPrefs.GetInt(": ", 0);
        updateCoins(totalCoins);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = ": " + highScore;

        for(int i =1; i < balls.Length; i++)
        {
            if(PlayerPrefs.GetInt("BallsUnlocked" +i,0) == 1)
            {
                balls[i].interactable = true;
            }
            else
            {
                balls[i].interactable= false;
            }
        }
        for(int j=0; j < playerExtraText.Length; j++)
        {
            playerExtraText[j].SetActive(false);
        }

        for (int i = 0; i < ballsText.Length; i++)
        {
            if (PlayerPrefs.GetInt("BallsTextState" + i, 1) == 0)  // If saved state is false (0)
            {
                ballsText[i].SetActive(false);
                playerExtraText[i].SetActive(true);
            }
            else
            {
                ballsText[i].SetActive(true);
                playerExtraText[i].SetActive(false);
            }
        }

    }

    void updateCoins(int coins)
    {
        coinsText.text = ": " + totalCoins;
    }
    public void SelectPlayer(int index)
    {
        SelectedPlayerIndex = index;
        PlayerPrefs.SetInt("SelectedPlayer", SelectedPlayerIndex);
    }

    public void getCoins(int coins)
    {
        coinsRequiredForUnlock = coins;
    }
    public void getBallIndex(int index)
    {
        ballIndex = index;
        UnlockPlayer(coinsRequiredForUnlock, index);
    }
  

    public void UnlockPlayer(int coins, int index)
    {
        unlockPlayerWindow.SetActive(true);
        backButton1.SetActive(false);
        nextButton.SetActive(false);
        if (coins <= totalCoins)
        {
            unlockPlayerWindowText.text = " Congratulations!\nYou Unlocked a New Player!";
            unlockImage.SetActive(true);
            totalCoins -= coins;
            updateCoins(totalCoins);
            PlayerPrefs.SetInt(": ", totalCoins);
          
            balls[index].interactable = true;
            PlayerPrefs.SetInt("BallsUnlocked" + index, 1);
            ballsText[index-1].SetActive(false);
            PlayerPrefs.SetInt("BallsTextState" + (index-1), 0);
           
        }
        else if( coins > totalCoins)
        {
            unlockPlayerWindowText.text = "Unable to Buy!\nTry Again!" ;
            lockImage.SetActive(true);
        }
    }
    public void backButton()
    {
        unlockPlayerWindow.SetActive(false);
        backButton1.SetActive(true);
        nextButton.SetActive(true);
    }

}
