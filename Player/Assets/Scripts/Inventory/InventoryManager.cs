using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryPanel;
    public Transform QuickInventory;
    public GameObject InventoryBG;
    private InventorySlot[] Slots;
    
    private void Awake()
    {
        Slots = new InventorySlot[InventoryPanel.transform.childCount + QuickInventory.childCount];
        for (int i = 0; i < Slots.Length; i++)
            if (i < QuickInventory.childCount)
                Slots[i] = QuickInventory.GetChild(i).GetComponent<InventorySlot>();
            else
                Slots[i] = InventoryPanel.transform.GetChild(i - QuickInventory.childCount).GetComponent<InventorySlot>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryPanel.SetActive(!InventoryPanel.active);
            InventoryBG.SetActive(InventoryPanel.active);
        } 
    }

    public bool TryAddItem(BaseItem item)
    {
        foreach (InventorySlot slot in Slots)
        {
            if (slot.item != null && slot.item.itemName == item.itemName && slot.amount != item.MaxAmount)
            {
                slot.amount++;
                slot.UpdateSlot();
                return true;
            }
        }
        foreach (InventorySlot slot in Slots)
        {
            if (slot.item == null) { 
                slot.item = item;
                slot.amount++;
                slot.UpdateSlot();
                return true;
            }
        }
        return false;
    }
}
