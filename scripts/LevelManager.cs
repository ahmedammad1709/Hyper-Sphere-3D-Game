using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;
    public Button[] lockButton;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    [SerializeField]private TextMeshProUGUI coinsText;

    private void Start()
    {
        int highScoe = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = ": " + highScoe;
        
        lockButton[0].gameObject.SetActive(false);
        lockButton[1].gameObject.SetActive(false);
        lockButton[2].gameObject.SetActive(false);
        lockButton[3].gameObject.SetActive(false);
        lockButton[4].gameObject.SetActive(false);
        lockButton[5].gameObject.SetActive(false);
        lockButton[6].gameObject.SetActive(false);
        lockButton[7].gameObject.SetActive(false);
        //int currentLevel = 1;
        int currentLevel = PlayerPrefs.GetInt("currentlevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            if(i+1 > currentLevel)
            {
                lockButton[i].gameObject.SetActive(true);
                lockButton[i].interactable = false;
                buttons[i].gameObject.SetActive(false);
               
            }
            else
            {
                lockButton[i].gameObject.SetActive(false);
                buttons[i].gameObject.SetActive(true);
                buttons[i].interactable = true;
               
            }
        }

        int totalCoins = PlayerPrefs.GetInt(": ", 0);
        coinsText.text = ": " + totalCoins;
    }

  
}
