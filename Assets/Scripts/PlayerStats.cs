using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string pName, race, pClass;
    public int currentLvl, currentExp, currentHp, currentMp, currentSta, currentAttack, currentDefence, currentPower, currentAgi, currentVit, currentInt, currentConst, statsPoints,
               tempStatsPoints, tempPower, tempAgi, tempVit, tempInt, tempConst;
    public int[] expToLvlUp;

    private PlayerHealthManager playerHp;
    private PlayerManaManager playerMp;
    private CharacterStats characterStats;
    private Character character;

    void Start()
    {


        character = GetComponent<Character>();
        characterStats = GetComponent<CharacterDatabase>().FetchCharacterByTipe("player");

        name = characterStats.Name;
        race = characterStats.Race;
        pClass = characterStats.Class;
        statsPoints = characterStats.Sp;
        tempStatsPoints = statsPoints;
        currentLvl = characterStats.Level;
        currentExp = characterStats.Exp;

        currentPower = characterStats.Power;
        currentAgi   = characterStats.Agility;
        currentVit   = characterStats.Vitality;
        currentInt   = characterStats.Inteligence;
        currentConst = characterStats.Constitution;

        tempPower = currentPower;
        tempAgi = currentAgi;
        tempVit = currentVit;
        tempInt = currentInt;
        tempConst = currentConst;

        currentHp = Mathf.RoundToInt(currentVit * 1.5f);
        currentMp = Mathf.RoundToInt(currentInt * 1.5f);
        currentSta = Mathf.RoundToInt(currentConst * 1.5f);
        currentAttack = Mathf.RoundToInt(currentPower * 1.5f);
        currentDefence = Mathf.RoundToInt(currentConst * 1.5f);
        playerHp = FindObjectOfType<PlayerHealthManager>();
        playerMp = FindObjectOfType<PlayerManaManager>();
    }

    void Update()
    {
        if (currentLvl < expToLvlUp.Length)
        {
            if (currentExp >= expToLvlUp[currentLvl])
            {
                LevelUp();
                character.StatsActualization();
            }
        }
    }

    public void LevelUp()
    {
        currentLvl++;
        statsPoints += 5;
        tempStatsPoints = statsPoints;
        playerHp.currentHP = currentHp;
        playerMp.currentMP = currentMp;
        
        /*currentHp = hpLvl[currentLvl-1];

        playerHp.maxHP = currentHp;
        playerHp.currentHP += currentHp - hpLvl[currentLvl - 1];

        currentAttack = attackLvl[currentLvl];
        currentDefence = defenceLvl[currentLvl];*/
    }

    public void StatsActualization()
    {
        currentHp = Mathf.RoundToInt(currentVit * 1.5f);
        currentMp = Mathf.RoundToInt(currentInt * 1.5f);
        currentSta = Mathf.RoundToInt(currentConst * 1.5f);
        currentAttack = Mathf.RoundToInt(currentPower * 1.5f);
        currentDefence = Mathf.RoundToInt(currentConst * 1.5f);
        playerHp.maxHP = currentHp;
        playerMp.maxMP = currentMp;
        playerHp.currentHP = currentHp;
        playerMp.currentMP = currentMp;
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
    }

    public void StatsPowerUp()
    {
        if (tempStatsPoints > 0)
        {
            tempPower++;
            tempStatsPoints--;
            character.powerTempMod.text = "+" + (tempPower - currentPower);
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }
    }

    public void StatsPowerDown()
    {
        if ((tempPower - currentPower) > 0 && tempStatsPoints < statsPoints)
        {
            tempStatsPoints++;
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }

        if ((tempPower - currentPower) > 0 && tempPower > currentPower)
        {
            tempPower--;
            character.powerTempMod.text = "+" + (tempPower - currentPower);
        }

        if ((tempPower - currentPower) == 0)
        {
            character.powerTempMod.text = "";
        }

        if(tempStatsPoints == statsPoints)
        {
            character.spTempMod.text = "";
        }
    }

    public void StatsAgiUp()
    {
        if (tempStatsPoints > 0)
        {
            tempAgi++;
            tempStatsPoints--;
            character.agilityTempMod.text = "+" + (tempAgi - currentAgi);
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }
    }

    public void StatsAgiDown()
    {
        if ((tempAgi - currentAgi) > 0 && tempStatsPoints < statsPoints)
        {
            tempStatsPoints++;
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }

        if ((tempAgi - currentAgi) > 0 && tempAgi > currentAgi)
        {
            tempAgi--;
            character.agilityTempMod.text = "+" + (tempAgi - currentAgi);
        }

        if ((tempAgi - currentAgi) == 0)
        {
            character.agilityTempMod.text = "";
        }

        if (tempStatsPoints == statsPoints)
        {
            character.spTempMod.text = "";
        }
    }

    public void StatsVitUp()
    {
        if (tempStatsPoints > 0)
        {
            tempVit++;
            tempStatsPoints--;
            character.vitalityTempMod.text = "+" + (tempVit - currentVit);
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }
    }

    public void StatsVitDown()
    {
        if ((tempVit - currentVit) > 0 && tempStatsPoints < statsPoints)
        {
            tempStatsPoints++;
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }

        if ((tempVit - currentVit) > 0 && tempVit > currentVit)
        {
            tempVit--;
            character.vitalityTempMod.text = "+" + (tempVit - currentVit);
        }

        if ((tempVit - currentVit) == 0)
        {
            character.vitalityTempMod.text = "";
        }

        if (tempStatsPoints == statsPoints)
        {
            character.spTempMod.text = "";
        }
    }


    public void StatsIntUp()
    {
        if (tempStatsPoints > 0)
        {
            tempInt++;
            tempStatsPoints--;
            character.inteligenceTempMod.text = "+" + (tempInt - currentInt);
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }
    }

    public void StatsIntDown()
    {
        if ((tempInt - currentInt) > 0 && tempStatsPoints < statsPoints)
        {
            tempStatsPoints++;
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }

        if ((tempInt - currentInt) > 0 && tempInt > currentInt)
        {
            tempInt--;
            character.inteligenceTempMod.text = "+" + (tempInt - currentInt);
        }

        if ((tempInt - currentInt) == 0)
        {
            character.inteligenceTempMod.text = "";
        }

        if (tempStatsPoints == statsPoints)
        {
            character.spTempMod.text = "";
        }
    }


    public void StatsConstUp()
    {
        if (tempStatsPoints > 0)
        {
            tempConst++;
            tempStatsPoints--;
            character.constituitionTempMod.text = "+" + (tempConst - currentConst);
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }
    }

    public void StatsConstDown()
    {
        if ((tempConst - currentConst) > 0 && tempStatsPoints < statsPoints)
        {
            tempStatsPoints++;
            character.spTempMod.text = "(" + (tempStatsPoints - statsPoints) + ")";
        }

        if ((tempConst - currentConst) > 0 && tempConst > currentConst)
        {
            tempConst--;
            character.constituitionTempMod.text = "+" + (tempConst - currentConst);
        }

        if ((tempConst - currentConst) == 0)
        {
            character.constituitionTempMod.text = "";
        }

        if (tempStatsPoints == statsPoints)
        {
            character.spTempMod.text = "";
        }
    }

    public void Finish()
    {
        currentPower = tempPower;
        currentAgi = tempAgi;
        currentVit = tempVit;
        currentInt = tempInt;
        currentConst = tempConst;
        statsPoints = tempStatsPoints;
        character.StatsActualization();
        character.powerTempMod.text = "";
        character.agilityTempMod.text = "";
        character.vitalityTempMod.text = "";
        character.inteligenceTempMod.text = "";
        character.constituitionTempMod.text = "";
        character.spTempMod.text = "";
    }
}