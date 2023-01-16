using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
    [SerializeField] private InputField howMuchToAdd;

    public void AddPoints()
    {
        PlayerPrefs.SetInt("currPoints", PlayerPrefs.GetInt("currPoints") + System.Convert.ToInt32(howMuchToAdd.text));
    }
}
