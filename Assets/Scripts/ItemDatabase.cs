using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Item.json"));
        ContructItemDatabase();

        Debug.Log(FetchItemByID(0).Description);
    }

    public Item FetchItemByID(int id)
    {
        for(int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    void ContructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item(
                (int)itemData[i]["id"],
                itemData[i]["title"].ToString(),
                (int)itemData[i]["value"],
                (int)itemData[i]["stats"]["attack"],
                (int)itemData[i]["stats"]["defense"],
                (int)itemData[i]["stats"]["power"],
                (int)itemData[i]["stats"]["agility"],
                (int)itemData[i]["stats"]["vitality"],
                (int)itemData[i]["stats"]["inteligence"],
                (int)itemData[i]["stats"]["constitution"],
                itemData[i]["description"].ToString(),
                (bool)itemData[i]["stackable"],
                (int)itemData[i]["rarity"],
                itemData[i]["slug"].ToString()
                ));
        }
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Power { get; set; }
    public int Agility { get; set; }
    public int Vitality { get; set; }
    public int Inteligence { get; set; }
    public int Constitution { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, int value, int attack, int defense, int power, int agility, int vitality, int inteligence, int constitution, string description, bool stackable, int rarity, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Attack = attack;
        this.Defense = defense;
        this.Power = power;
        this.Agility = agility;
        this.Vitality = vitality;
        this.Inteligence = inteligence;
        this.Constitution = constitution;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public Item()
    {
        this.ID = -1;
    }
}