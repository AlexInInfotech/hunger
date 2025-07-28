using UnityEngine;
using UnityEngine.UI;

public class QuickslotInventory : MonoBehaviour
{
    public Transform quickslotParent;
    public int currentQuickslotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    private InventorySlot slot;

    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw > 0.1)
        {
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            if (currentQuickslotID >= quickslotParent.childCount - 1)
                currentQuickslotID = 0;
            else
                currentQuickslotID++;
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
        }
        if (mw < -0.1)
        {
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            if (currentQuickslotID <= 0)
                currentQuickslotID = quickslotParent.childCount - 1;
            else
                currentQuickslotID--;
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
        }
        for (int i = 0; i < quickslotParent.childCount; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
                if (currentQuickslotID == i)
                    if (quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                    else
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                else
                {
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    currentQuickslotID = i;
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            slot = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
            if (slot.item != null && slot.item.isConsumeable && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)
            {
                slot.item.Use();
                if (slot.amount <= 1)
                    slot.ClearSlot();
                else
                {
                    slot.amount--;
                    slot.UpdateSlot();
                }
            }
        }
    }
}
