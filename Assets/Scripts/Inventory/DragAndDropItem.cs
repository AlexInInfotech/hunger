using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Reflection;
/// IPointerDownHandler - Следит за нажатиями мышки по объекту на котором висит этот скрипт
/// IPointerUpHandler - Следит за отпусканием мышки по объекту на котором висит этот скрипт
/// IDragHandler - Следит за тем не водим ли мы нажатую мышку по объекту
public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public InventorySlot oldSlot;
    public float speed = 1f;
    private InventorySlot newSlot;
    //public Transform player;
    public void OnDrag(PointerEventData eventData)
    {
        if (oldSlot.item == null)
            return;
        GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y) * Time.deltaTime *speed;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (oldSlot.item == null)
            return;
        //GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        GetComponentInChildren<Image>().raycastTarget = false;
        transform.SetParent(transform.parent.parent.parent);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (oldSlot.item == null)
            return;
       // GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        GetComponentInChildren<Image>().raycastTarget = true;

        transform.SetParent(oldSlot.transform);
        transform.position = oldSlot.transform.position;
        if (eventData.pointerCurrentRaycast.gameObject == null)//нажатие на тот же слот на котором был предмет
            Debug.Log("NULLL");
        else
        {
            if (eventData.pointerCurrentRaycast.gameObject.name != "Icon"
                && eventData.pointerCurrentRaycast.gameObject.name != "QuickInventory")
            {
                Debug.Log("Throw");
                oldSlot.ClearSlot();
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "Icon")// || eventData.pointerCurrentRaycast.gameObject.name == "Slot")
            {
                if (!eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.TryGetComponent<InventorySlot>(out newSlot))
                    return;
                if (newSlot.item != null && newSlot.item.itemName == oldSlot.item.itemName)
                    StackSlots(newSlot);
                else
                    ExchangeSlotData(newSlot);
            }
        }
        //if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent == null)
        //    return;
        //if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.TryGetComponent<InventorySlot>(out InventorySlot newSlot))
        //    if (newSlot.item != null && newSlot.item.itemName == oldSlot.item.itemName)
        //        StackSlots(newSlot);
        //    else
        //        ExchangeSlotData(newSlot);
        //else
        //{
        //    Debug.Log("Throw");
        //    oldSlot.ClearSlot();
        //}


    }

    void StackSlots(InventorySlot newSlot)
    {
        newSlot.amount += oldSlot.amount;
        if (newSlot.amount > newSlot.item.MaxAmount)
        {
            oldSlot.amount = newSlot.amount - newSlot.item.MaxAmount;
            newSlot.amount = newSlot.item.MaxAmount;
            oldSlot.UpdateSlot();
        }
        else
            oldSlot.ClearSlot();
        newSlot.UpdateSlot();
    }
    void ExchangeSlotData(InventorySlot newSlot)
    {
        BaseItem newItem = newSlot.item;
        int newAmount = newSlot.amount;

        newSlot.item = oldSlot.item;
        newSlot.amount = oldSlot.amount;
        newSlot.UpdateSlot();

        oldSlot.item = newItem;
        oldSlot.amount = newAmount;
        oldSlot.UpdateSlot();

    }
}
