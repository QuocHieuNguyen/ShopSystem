using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/ItemData")]
public class ItemData : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public string itemValue;
    public int valuePrice;
    public int amount;
    public int level = 1;
    public int maxLevel;
    public int upgradePrice;
    public int levelUnlock = 0;
    public bool isUnlock = true;
    public float priceToUnlock;
    public ItemType type;

}
public enum ItemType
{
    Weapon,
    Armor,
    Boot,
    Helmet
}
