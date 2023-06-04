using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Scriptables/Items/Weapon")]
public class ItemWeapon : Item
{
    public int attackPower;
    public bool consumesItemToUse;
    [EnableIf("consumesItemToUse")]
    [AllowNesting]
    public Item requiredItemToUse;
}
