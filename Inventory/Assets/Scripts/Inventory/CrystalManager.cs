using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour
{
    public Text amountUI;
    public int totalCrystal;

    void Start()
    {
        UpdateUI();
    }
    void UpdateUI()
    {
        amountUI.text = totalCrystal.ToString();
    }
    public bool IsEnoughCrystal(int amount)
    {
        if(totalCrystal >= amount)
        {
            return true;
        }else return false;
    }
    public void DecreaseCrystal(int amount)
    {
        totalCrystal -= amount;
        UpdateUI();
    }
    public void IncreaseCrystal(int amount)
    {
        totalCrystal += amount;
        UpdateUI();
    }
}
