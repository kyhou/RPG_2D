using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    InventoryDatabase itemsInventory;
    int slotAmount, itemAmount;
    int[] itemsInInvetory;

    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();
        itemsInventory = GetComponent<InventoryDatabase>();

        slotAmount = 20;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for(int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<InventorySlot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
            slots[i].name = "Slot";
        }


        itemsInInvetory = itemsInventory.FetchAllItemsIDs();

        for(int i = 0; i < itemsInInvetory.Length; i++)
        {
            itemAmount = itemsInventory.FetchItemsAmount(i);
            for (int a = 0; a < itemAmount; a++)
            {
                AddItem(itemsInInvetory[i]);
            }
        }

        inventoryPanel.SetActive(false);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);

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
                    itemObj.name = itemToAdd.Title + " Item";
                    break;
                }
            }
        }


    }

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