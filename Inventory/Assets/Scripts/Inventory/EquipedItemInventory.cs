using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedItemInventory : MonoBehaviour
{
    public List<EquipedItemHolder> equipedItems = new List<EquipedItemHolder>() ;
    void Start()
    {
        for (int i = 0; i < equipedItems.Count; i++)
        {
            equipedItems[i].equipedItemInventory = this;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            UnequipItem(equipedItems[0]);
        }
    }
    public void EquipItem(ItemData data, string name)
    {
        if(IsAlreadyEquiped(name))
        {
            for (int i = 0; i < equipedItems.Count; i++)
            {
                if(equipedItems[i].itemName == name)
                {
                    equipedItems[i].itemName = name;
                    equipedItems[i].itemData = data;
                    equipedItems[i].UpdateUI();
                    break;
                }                
            }
        }
        if(!IsFull() && !IsAlreadyEquiped(name))
        {
            for (int i = 0; i < equipedItems.Count; i++)
            {
                if(equipedItems[i].itemName == "")
                {
                    equipedItems[i].itemName = name;
                    equipedItems[i].itemData = data;
                    equipedItems[i].UpdateUI();
                    break;
                }
            }
        }else
        {
            Debug.Log("The Inventory is Full");
        }
    }
    public bool IsFull()
    {
        bool value = true;
        for (int i = 0; i < equipedItems.Count; i++)
        {
            if(equipedItems[i].itemName == "")
            {
                value = false;
                break;
                //return value;
            }
        }
        return value;
    }
    public bool IsAlreadyEquiped(string name)
    {
        bool value = false;
        for (int i = 0; i < equipedItems.Count; i++)
        {
            if(equipedItems[i].itemName == name)
            {
                value = true;
                break;
            }
        }
        return value;
    }
    public void UnequipItem(EquipedItemHolder equipedItem)
    {
        equipedItem.ResetGivenData();
        for (int i = 0; i < equipedItems.Count; i++)
        {
            if(equipedItems.IndexOf(equipedItem) < i)
            {                
                Vector3 tempPos = equipedItem.gameObject.transform.position;
                
                equipedItem.gameObject.transform.position = equipedItems[i].gameObject.transform.position;
                
                equipedItems[i].gameObject.transform.position = tempPos;                    
            }
        }
        EquipedItemHolder tempItem = equipedItem;
        equipedItems.Remove(equipedItem);
        equipedItems.Add(tempItem);
    }
}
