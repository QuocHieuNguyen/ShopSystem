using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Shop : MonoBehaviour
{

    public List<ItemData> itemData = new List<ItemData>();
    public GameObject itemHolder;
    public Transform parent;
    public GoldManager goldManager;
    public CrystalManager crystalManager;
    public EquipedItemInventory equipedItemInventory;
    public List<GameObject> itemHolders = new List<GameObject>();
    public Button weaponTag, armorTag, bootTag, helmetTag;

    void Start()
    {
        InitItem();
        weaponTag.onClick.AddListener(() => CategorizeItem(ItemType.Weapon));
        armorTag.onClick.AddListener(() => CategorizeItem(ItemType.Armor));
        bootTag.onClick.AddListener(() => CategorizeItem(ItemType.Boot));
        helmetTag.onClick.AddListener(() => CategorizeItem(ItemType.Helmet));

        weaponTag.onClick.Invoke();

    }
     
    public void InitItem()
    {
        
        for (int i = 0; i < itemData.Count; i++)
        {
            GameObject g = (GameObject)Instantiate(itemHolder, parent);
            g.SetActive(false);
            itemHolders.Add(g);
            ItemHolder iHolder = g.GetComponent<ItemHolder>();
            iHolder.name = itemData[i].name;
            iHolder.image.sprite = itemData[i].sprite;
            iHolder.amount = itemData[i].amount;
            iHolder.itemValue = itemData[i].itemValue;
            iHolder.valuePrice = itemData[i].valuePrice;
            iHolder.upgradePrice = itemData[i].upgradePrice;
            iHolder.level = itemData[i].level;
            iHolder.maxLevel = itemData[i].maxLevel;
            iHolder.levelUnlock = itemData[i].levelUnlock;
            iHolder.isUnlock = itemData[i].isUnlock;
            iHolder.priceToUnlock = itemData[i].priceToUnlock;
            iHolder.data = itemData[i];
            iHolder.type = itemData[i].type;
            iHolder.goldManager = goldManager;
            iHolder.crystalManager = crystalManager;
            iHolder.equipedItemInventory = equipedItemInventory;
            iHolder.UpdateUI();
        }
    }
    // public void ClearList()
    // {
    //     for (int i = 0; i < itemHolders.Count; i++)
    //     {
    //         Destroy(itemHolders[i]);
    //     }
    //     itemHolders.Clear();
    //     itemData.Clear();
    // }
    // public void AddData(List<ItemData> list)
    // {
    //     //ClearList();
    //     foreach (ItemData item in list)
    //     {
    //         itemData.Add(item);
    //     }
    //     //InitItem();
    // }
    public void CategorizeItem(ItemType itemType)
    {
        for (int i = 0; i < itemHolders.Count; i++)
        {
            if(itemHolders[i].GetComponent<ItemHolder>().type == itemType)
            {
                itemHolders[i].SetActive(true);
            }else
            {
                itemHolders[i].SetActive(false);
            }
        }
        //InitItem();
    }
    // public void CreateArmorItem()
    // {
    //     List<ItemData> items =  new List<ArmorData>().ConvertAll(x => (ItemData)x);
    //     AddData(items);
    //     //InitItem();
    // }
    // public void CreateBootItem()
    // {
    //     List<ItemData> items =  new List<BootData>().ConvertAll(x => (ItemData)x);
    //     AddData(items);
    //     //InitItem();
    // }
    // public void CreateHelmetItem()
    // {
    //     List<ItemData> items =  new List<WeaponData>().ConvertAll(x => (ItemData)x);
    //     AddData(items);
    //     //InitItem();
    // }
}
