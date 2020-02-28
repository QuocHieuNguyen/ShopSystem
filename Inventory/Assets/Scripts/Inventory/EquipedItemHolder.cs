using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipedItemHolder : MonoBehaviour
{
    public string itemName;
    public Image equipedItemImage;
    public Text amount;
    public ItemData itemData;
    public GoldManager goldManager;
    public EquipedItemInventory equipedItemInventory;
    public Button unequipedButton;

    public void UpdateUI()
    {
        equipedItemImage.sprite = itemData.sprite;
        amount.text = itemData.amount.ToString();
        unequipedButton.onClick.AddListener(UnequipedButtonClicked);
    }
    public void ResetGivenData()
    {
        itemName = "";
        equipedItemImage.sprite = null;
        amount.text = "";
        itemData = null;
    }
    public void UnequipedButtonClicked()
    {
        equipedItemInventory.UnequipItem(this);
    }
}
