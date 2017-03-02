using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class InventoryDatabase : MonoBehaviour
{
    private List<InventoryItems> inventoryItems = new List<InventoryItems>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Inventory.json"));
        ContructDatabase();
    }

    public int[] FetchAllItemsIDs()
    {
        int[] IDs = new int[inventoryItems.Count];

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            IDs[i] = inventoryItems[i].ID;
        }

        return IDs;

    }

    public int FetchItemsAmount(int id)
    {
        int amount = inventoryItems[id].Amount;
        return amount;
    }


    void ContructDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            inventoryItems.Add(new InventoryItems(
                (int)itemData[i]["id"],
                (int)itemData[i]["slot_id"],
                (int)itemData[i]["amount"]
                ));
        }
    }
}

public class InventoryItems
{
    public int ID { get; set; }
    public int Slot_id { get; set; }
    public int Amount { get; set; }

    public InventoryItems(int id, int slot_id, int amount)
    {
        this.ID = id;
        this.Slot_id = slot_id;
        this.Amount = amount;
    }

    public InventoryItems()
    {
        this.ID = -1;
    }
}