using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text amountUI;
    public int totalGold;

    void Start()
    {
        UpdateUI();
    }
    void UpdateUI()
    {
        amountUI.text = totalGold.ToString();
    }
    public bool IsEnoughGold(int amount)
    {
        if(totalGold >= amount)
        {
            return true;
        }else return false;
    }
    public void DecreaseGold(int amount)
    {
        totalGold -= amount;
        UpdateUI();
    }
    public void IncreaseGold(int amount)
    {
        totalGold += amount;
        UpdateUI();
    }
}
