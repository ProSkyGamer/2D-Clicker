using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnMe : MonoBehaviour
{
    [SerializeField] private bool isNeedToShowPointsPerSecond;

    private Text pointCounter;
    private Text generatingPointsCounter;

    private bool isOnCD;

    private int generatePerClick;

    private void Awake()
    {
        if(pointCounter == null)
            pointCounter = gameObject.GetComponent<Text>();
        if(isNeedToShowPointsPerSecond)
            if (generatingPointsCounter == null)
                generatingPointsCounter = gameObject.GetComponentsInChildren<Text>()[1];

        pointCounter.text = PlayerPrefs.GetInt("currPoints").ToString();
        if(isNeedToShowPointsPerSecond)
            generatingPointsCounter.text = PlayerPrefs.GetInt("cuurPointsGenerating").ToString();
    }

    private void Update()
    {
        UpdateCount();
    }

    public void OnButtonClick()
    {
        if (!isOnCD)
        {
            generatePerClick = Mathf.RoundToInt(PlayerPrefs.GetInt("cuurPointsGenerating") / 5);
            if (generatePerClick < 1)
                generatePerClick = 1;
            PlayerPrefs.SetInt("currPoints", PlayerPrefs.GetInt("currPoints") + Mathf.RoundToInt(PlayerPrefs.GetInt("cuurPointsGenerating")/5));

            isOnCD = true;
            StartCoroutine(ClickCoolDown());
        }
    }

    private void UpdateCount()
    {
        pointCounter.text = PlayerPrefs.GetInt("currPoints").ToString();
        if(isNeedToShowPointsPerSecond)
            generatingPointsCounter.text = PlayerPrefs.GetInt("cuurPointsGenerating").ToString();
    }

    private IEnumerator ClickCoolDown()
    {
        yield return new WaitForSeconds(0.3f);
        isOnCD = false;
    }

}
