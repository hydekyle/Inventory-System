using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDurability
{
    public void LoseDurability(int durabilityAmount);
    public void RepairDurability();
}