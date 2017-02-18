using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSlot : MonoBehaviour//, IDropHandler
{/*
    public int id;
    //public string type;

    private Character charInv;

    void Start()
    {
        charInv = GameObject.Find("Character").GetComponent<Character>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if(charInv.items[id].ID == -1)
        {
            charInv.items[droppedItem.slot] = new Item();
            charInv.items[id] = droppedItem.item;
            droppedItem.slot = id;
        }
        else if(droppedItem.slot != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slot = droppedItem.slot;
            item.transform.SetParent(charInv.slots[droppedItem.slot].transform);
            item.transform.position = charInv.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            charInv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
            charInv.items[id] = droppedItem.item;
        }
    }

    void Update()
    {

    }*/
}