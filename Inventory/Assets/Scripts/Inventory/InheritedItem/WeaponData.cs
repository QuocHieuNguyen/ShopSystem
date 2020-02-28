using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/WeaponData")]
public class WeaponData : ItemData
{
    public float damage;
    public float attackSpeed;
    public float critRate;
    public float critDamage;
    public bool haveStunSkill = false;
    public bool haveFreezeSkill = false;
    public bool haveBurnSkill = false;
    public bool havePoisonSkill = false;

}
