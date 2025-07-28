using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public BaseItem item;
    public int amount;
    public GameObject icon; 
    public TextMeshProUGUI textMesh;
    public void UpdateSlot()
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }
        icon.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        icon.GetComponent<Image>().sprite = item.Sprite;
        textMesh.text = amount.ToString();
    }
    public void ClearSlot()
    {
        item = null;
        amount = 0;
        icon.GetComponent<Image>().sprite = null;
        icon.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        textMesh.text = "";
    }
}
