using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class CharacterDatabase : MonoBehaviour
{
    private List<CharacterStats> character = new List<CharacterStats>();
    private JsonData characterData;

    void Start()
    {
        characterData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Character.json"));
        ContructItemDatabase();
    }

    public CharacterStats FetchCharacterByTipe(string tipe)
    {
        for (int i = 0; i < character.Count; i++)
        {
            if (character[i].Tipe == tipe)
            {
                return character[i];
            }
        }
        return null;
    }

    public CharacterStats FetchCharacterByName(string tipe)
    {
        for (int i = 0; i < character.Count; i++)
        {
            if (character[i].Name == name)
            {
                return character[i];
            }
        }
        return null;
    }

    /*public int[] FetchAllItemsIDs()
    {
        int[] IDs = new int[character.Count];

        for (int i = 0; i < character.Count; i++)
        {
            IDs[i] = character[i].ID;
        }

        return IDs;

    }

    public int FetchItemsAmount(int id)
    {
        int amount = character[id].Amount;
        return amount;
    }*/


    void ContructItemDatabase()
    {
        for (int i = 0; i < characterData.Count; i++)
        {
            character.Add(new CharacterStats(
                characterData[i]["tipe"].ToString(),
                characterData[i]["name"].ToString(),
                characterData[i]["race"].ToString(),
                /*characterData[i]["titles"]["title"].ToString(),
                characterData[i]["titles"]["description"].ToString(),
                characterData[i]["titles"]["requirement"]["description"].ToString(),
                characterData[i]["titles"]["requirement"]["condition"].ToString(),
                (int)characterData[i]["titles"]["requirement"]["amount"],
                characterData[i]["titles"]["bonus"]["value1"].ToString(),
                characterData[i]["titles"]["bonus"]["value2"].ToString(),
                (int)characterData[i]["titles"]["bonus"]["value3"],*/
                (int)characterData[i]["level"],
                (int)characterData[i]["exp"],
                characterData[i]["class"].ToString(),
                (int)characterData[i]["stats"]["power"],
                (int)characterData[i]["stats"]["agility"],
                (int)characterData[i]["stats"]["vitality"],
                (int)characterData[i]["stats"]["inteligence"],
                (int)characterData[i]["stats"]["constitution"],
                (int)characterData[i]["sp"]
                ));
        }
    }
}

public class CharacterStats
{
    public string Tipe { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    /*public string TitlesTile { get; set; }
    public string TitlesDescriptions { get; set; }
    public string TitlesRequirementDescription { get; set; }
    public string TitlesRequirementCondition { get; set; }
    public int TitlesRequirementAmount { get; set; }
    public string TitlesBonusValue1 { get; set; }
    public string TitlesBonusValue2 { get; set; }
    public int TitlesBonusValue3 { get; set; }*/
    public int Level { get; set; }
    public int Exp { get; set; }
    public string Class { get; set; }
    public int Power { get; set; }
    public int Agility { get; set; }
    public int Vitality { get; set; }
    public int Inteligence { get; set; }
    public int Constitution { get; set; }
    public int Sp { get; set; }

    public CharacterStats(string tipe, string name, string race, /*string titlesTile, string titlesDescriptions, string titlesRequirementDescription, string titlesRequirementCondition, int titlesRequirementAmount,
                          string titlesBonusValue1, string titlesBonusValue2, int titlesBonusValue3,*/ int level, int exp, string cClass, int power, int agility, int vitality, int inteligence, int constitution, int sp)
    {
        this.Tipe                         = tipe;
        this.Name                         = name;
        this.Race                         = race;
        /*this.TitlesTile                   = titlesTile;
        this.TitlesDescriptions           = titlesDescriptions;
        this.TitlesRequirementDescription = titlesRequirementDescription;
        this.TitlesRequirementCondition   = titlesRequirementCondition;
        this.TitlesRequirementAmount      = titlesRequirementAmount;
        this.TitlesBonusValue1            = titlesBonusValue1;
        this.TitlesBonusValue2            = titlesBonusValue2;
        this.TitlesBonusValue3            = titlesBonusValue3;*/
        this.Level                        = level;
        this.Exp                          = exp;
        this.Class                        = cClass;
        this.Power                        = power;
        this.Agility                      = agility;
        this.Vitality                     = vitality;
        this.Inteligence                  = inteligence;
        this.Constitution                 = constitution;
        this.Sp                           = sp;
    }

    public CharacterStats()
    {
        this.Name = null;
    }
}