using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator : MonoBehaviour
{
    private bool isNowGenerating;

    private void Update()
    {
        if(!isNowGenerating)
        {
            isNowGenerating = true;
            StartCoroutine(GenerateCoins(PlayerPrefs.GetInt("cuurPointsGenerating")));
        }    
    }

    private IEnumerator GenerateCoins(int coinsToGenerate)
    {
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("currPoints", PlayerPrefs.GetInt("currPoints") + coinsToGenerate);
        isNowGenerating = false;
    }
}
