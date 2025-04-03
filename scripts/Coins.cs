using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public int playerCoins;
    [SerializeField] private TextMeshProUGUI coinsText;
  

    void Start()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
        if (coinsText == null)
        {
            Debug.Log("Null reff");
        }
        
    }
    void Update()
    {
        coinsText.text = ": " + playerCoins;
    }


    public void coinIncrease()
    {
        playerCoins ++;
        BucketCoins bucket = FindFirstObjectByType<BucketCoins>();
        if(bucket != null)
        {
            bucket.AddCoinToBucket();
        }
      
    
    }

}
