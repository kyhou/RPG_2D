using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLvl, currentExp, currentHp, currentMp, currentSta, currentAttack, currentDefence, currentPower, currentAgi, currentVit, currentInt, currentConst, statsPoints;
    public int[] expToLvlUp/*, hpLvl, mpLvl, staLvl, attackLvl, defenceLvl, vitLvl, powerLvl, agiLvl, intLvl, constLvl*/;

    private PlayerHealthManager playerHp;
    private PlayerManaManager playerMp;

    void Start()
    {
        /*currentHp = hpLvl[currentLvl];
        currentAttack = attackLvl[currentLvl];
        currentDefence = defenceLvl[currentLvl];*/

        currentPower = 10;
        currentAgi   = 10;
        currentVit   = 10;
        currentInt   = 10;
        currentConst = 10;

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
            }
        }
    }

    public void LevelUp()
    {
        currentLvl++;
        statsPoints += 5;
        playerHp.currentHP = currentHp;
        playerMp.currentMP = currentMp;

        /*currentHp = hpLvl[currentLvl-1];

        playerHp.maxHP = currentHp;
        playerHp.currentHP += currentHp - hpLvl[currentLvl - 1];

        currentAttack = attackLvl[currentLvl];
        currentDefence = defenceLvl[currentLvl];*/
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
    }
}