using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    [Header("Data")]
    public string name;
    public Image image;
    public int amount;
    public string itemValue;
    public int valuePrice;
    public int upgradePrice;
    public int level = 1;
    public int maxLevel;
    public int levelUnlock = 1;
    public bool isUnlock;
    public float priceToUnlock;
    [Header("Detail Data")]
    public ItemData data;
    public ItemType type;
    [Header("UI")]
    public Text itemName;
    public Text itemAmount;
    public Text itemUpgradePrice;
    public Text itemValuePrice;
    public ProgressBar pb;
    public Button equipButton;
    public Button upgradeButton;
    public Button buyValueButton;
    public Text itemValueText;
    public Text levelUnlockText;
    public Text priceToUnlockText;
    public Button unlockButton;
    public GameObject lockPanel;
    [Header("GoldManager")]
    public GoldManager goldManager;
    public CrystalManager crystalManager;
    [Header("EquipedItemInventory")]
    public EquipedItemInventory equipedItemInventory;

    public void UpdateUI()
    {
        //Basic Component
        itemName.text = name;
        itemAmount.text = amount.ToString();
        itemUpgradePrice.text = upgradePrice.ToString();
        itemValuePrice.text = valuePrice.ToString();
        itemValueText.text = itemValue.ToString();
        if(maxLevel != 0)
        {
            pb.BarValue = 100/maxLevel * level;
        }
        //Button
        equipButton.onClick.AddListener(EquipButtonClicked);
        upgradeButton.onClick.AddListener(UpgradeButtonClicked);
        buyValueButton.onClick.AddListener(BuyValueButtonClicked);
        //Lock Panel
        levelUnlockText.text = "LV :" +levelUnlock;
        priceToUnlockText.text = priceToUnlock.ToString();
        lockPanel.SetActive(!isUnlock);
        unlockButton.onClick.AddListener(UnlockButtonClicked);
    }
    public void EquipButtonClicked()
    {
        Debug.Log("Equip "+ name);
        equipedItemInventory.EquipItem(data,name );
    }
    public void UpgradeButtonClicked()
    {
        if(goldManager.IsEnoughGold(upgradePrice))
        {
            Debug.Log("Upgrade " + name);
            pb.BarValue += 1;
            goldManager.DecreaseGold(upgradePrice);
        }
    }
    public void BuyValueButtonClicked()
    {
        if(goldManager.IsEnoughGold(valuePrice))
        {
            Debug.Log("Buy " + itemValue + " " + name);
            goldManager.DecreaseGold(valuePrice);
            amount++;
            data.amount = amount;
            itemAmount.text = amount.ToString();
        }
        
    }
    public void UnlockButtonClicked()
    {
        if(crystalManager.IsEnoughCrystal(Mathf.RoundToInt(priceToUnlock)))
        {
            crystalManager.DecreaseCrystal(Mathf.RoundToInt(priceToUnlock));
            isUnlock = false;
            lockPanel.SetActive(false);
        }
    }
}
