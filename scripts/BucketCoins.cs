using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BucketCoins : MonoBehaviour
{
    private int bucketCoins = 0; 
    public int totalCoins = 10; 
    public Slider slider;
    public TextMeshProUGUI sliderText;
    private int counter;

    private void Start()
    {
        slider.value = 0;
        slider.maxValue = totalCoins;
        sliderText.text = "0"; 
    }

    private void Update()
    {
        //int currentCoins = FindFirstObjectByType<Coins>().playerCoins; // Get total player coins

        if (bucketCoins < totalCoins)
        {
            slider.value = bucketCoins;
        }
        else if (bucketCoins >= totalCoins)
        {
            counter++;
            sliderText.text = counter.ToString();

            bucketCoins = 0;
            slider.value = 0;

            Debug.Log("Bucket Filled! Counter: " + counter);
        }
    }

    public void AddCoinToBucket()
    {
        bucketCoins++;
    }
}
