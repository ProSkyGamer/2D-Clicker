using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingItems : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] private int startCost;
    [SerializeField] private int generatePerSecond;
    private int currCost;
    private Text priceText;
    private Text itemCount;
    private BuyingItems[] allItems;

    private void Start()
    {
        allItems = gameObject.GetComponentInParent<GridLayoutGroup>().gameObject.GetComponentsInChildren<BuyingItems>();

        for (int i = 1; i < allItems.Length + 1; i++)
        {
            if (allItems[0].gameObject == gameObject && i != 1)
            {
                if (PlayerPrefs.GetInt(allItems[i - 2].itemName + "buyed") > 0)
                {
                    allItems[i - 1].gameObject.GetComponentInChildren<RawImage>().gameObject.SetActive(false);
                }
            }
        }

        currCost = startCost;
        for (int i = 1; i <= PlayerPrefs.GetInt(itemName + "buyed"); i++)
        {
            currCost = Mathf.RoundToInt(currCost * 1.25f);
        }

        priceText = gameObject.GetComponentsInChildren<Text>()[1];
        priceText.text = currCost.ToString();

        itemCount = gameObject.GetComponentsInChildren<Text>()[2];
        itemCount.text = PlayerPrefs.GetInt(itemName + "buyed").ToString();
    }

    private void CheckNewItemAvailibility()
    {
        for (int i = 1; i < allItems.Length + 1; i++)
        {
            if (allItems[i - 1].gameObject == gameObject)
                if (i <= allItems.Length - 1)
                    if (allItems[i].gameObject.GetComponentInChildren<RawImage>() != null)
                        allItems[i].gameObject.GetComponentInChildren<RawImage>().gameObject.SetActive(false);
        }

    }

    public void BuyItem()
    {
        if (PlayerPrefs.GetInt("currPoints") >= currCost)
        {
            PlayerPrefs.SetInt("currPoints", PlayerPrefs.GetInt("currPoints") - currCost);
            PlayerPrefs.SetInt("cuurPointsGenerating", PlayerPrefs.GetInt("cuurPointsGenerating") + generatePerSecond);

            currCost = Mathf.RoundToInt(currCost * 1.25f);
            priceText.text = currCost.ToString();

            PlayerPrefs.SetInt(itemName + "buyed", PlayerPrefs.GetInt(itemName + "buyed") + 1);
            itemCount.text = PlayerPrefs.GetInt(itemName + "buyed").ToString();
            CheckNewItemAvailibility();

        }
    }
}
