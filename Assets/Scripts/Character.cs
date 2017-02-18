using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    GameObject characterPanel;
    GameObject slotPanel;
    InventoryDatabase database;
    int slotAmount;

    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public List<InventoryItems> items = new List<InventoryItems>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<InventoryDatabase>();

        //slotAmount = 20;
        characterPanel = GameObject.Find("Inventory Panel");
        slotPanel = characterPanel.transform.FindChild("Slot Panel").gameObject;
        /*for(int i = 0; i < slotAmount; i++)
        {
            items.Add(new InventoryItems());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<InventorySlot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }

        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(2);
        AddItem(3);
        AddItem(3);*/

        characterPanel.SetActive(false);
    }

    /*public void AddItem(int id)
    {
        InventoryItems itemToAdd = database.FetchItemByID(id);

        if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().amount = 1;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = Vector2.zero;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = itemToAdd.Title;
                    break;
                }
            }
        }


    }*/

    bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return true;
        }
        return false;
    }
}