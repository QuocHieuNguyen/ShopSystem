using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/ArmorData")]
public class ArmorData : ItemData
{
    public float healthBonus;
    public float poisonResist;
    public float freezeResist;
    public float stunResist;
    public float burnResist;

}
