using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, /*IBeginDragHandler,*/ IDragHandler,/* IEndDragHandler,*/ IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler ,IPointerUpHandler
{
    public Item item;
    public int amount;
    public int slot;

    private Tooltip tooltip;
    private Inventory inv;
    private Vector2 offset;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();
    }

    public void OnPointerDown /*OnBeginDrag*/ (PointerEventData eventData)
    {
        if (item != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offset;
        }
    }

    public void OnPointerUp /*OnEndDrag*/ (PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            SendDraggedItemToOriginalPosition();
        }
        if (eventData.pointerCurrentRaycast.gameObject.name.Contains("Slot") && !eventData.pointerCurrentRaycast.gameObject.name.Contains("Panel"))
        {
            GameObject draggedItem = this.gameObject;
            GameObject newSlot = eventData.pointerCurrentRaycast.gameObject;

            //the parent original parent of the dragged item can be accessed via the slot location value.
            //change the name of the original slot to 'empty slot'
            inv.slots[slot].name = "Empty Slot";
            //set the inventory item at the original location to null
            inv.items[slot] = new Item();
            //set the parent and location of the dragged item to the new slot
            draggedItem.transform.SetParent(newSlot.transform);
            draggedItem.transform.position = newSlot.transform.position;
            //change the slot location of the dragged item so it reflects its new position
            slot = newSlot.GetComponent<InventorySlot>().id;
            //change the inventory item index at the new position to the dragged item
            inv.items[slot] = item;
            //change the name of the new slot so it reflects its child item
            newSlot.name = item.Title + " Slot";
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name.Contains("Item"))
        {
            GameObject draggedItem = this.gameObject;
            GameObject itemClicked = eventData.pointerCurrentRaycast.gameObject;

            //swap the two item slot locations
            draggedItem.transform.SetParent(inv.slots[itemClicked.GetComponent<ItemData>().slot].transform);
            draggedItem.transform.position = inv.slots[itemClicked.GetComponent<ItemData>().slot].transform.position;
            itemClicked.transform.SetParent(inv.slots[slot].transform);
            itemClicked.transform.position = inv.slots[slot].transform.position;
            //swap the items' position in the items list
            inv.items[itemClicked.GetComponent<ItemData>().slot] = item;
            inv.items[slot] = itemClicked.GetComponent<ItemData>().item;
            //change the slotLocation values so they reflect their current slot parent. Make sure itemclicked is done 
            //first otherwise there will be errors
            itemClicked.GetComponent<ItemData>().slot = slot;
            draggedItem.GetComponent<ItemData>().slot = gameObject.transform.parent.GetComponent<InventorySlot>().id;
            //change the names of the slot so they reflect the names of their child items
            itemClicked.transform.parent.name = itemClicked.GetComponent<ItemData>().item.Title + " Slot";
            draggedItem.transform.parent.name = draggedItem.GetComponent<ItemData>().item.Title + " Slot";
       }
        else
        {
            SendDraggedItemToOriginalPosition();
        }
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }

    public void SendDraggedItemToOriginalPosition()
    {
        this.transform.SetParent(inv.slots[slot].transform);
        inv.slots[slot].name = item.Slug + " Slot";
        this.transform.position = inv.slots[slot].transform.position;
    }
}