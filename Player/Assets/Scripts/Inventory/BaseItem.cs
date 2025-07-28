using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : ScriptableObject
{
    public ItemType type;
    public Sprite Sprite;
    public string itemName;
    public int MaxAmount;
    public bool isConsumeable;

    public virtual void Use()
    {
        Debug.Log("Base used");
    }
}
