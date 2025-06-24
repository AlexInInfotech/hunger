using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/New Food Item")]
public class FoodItem : BaseItem
{
    public int HealAmount;
    public int HungryAmount;
    public override void  Use()
    {
        Debug.Log("Food Used with " + HealAmount);
        PlayerCharacteristics.Eat(HealAmount, HungryAmount);

    }
}
