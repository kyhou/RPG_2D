using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider HpBar, MpBar, ExpBar;
    public Text HpText, MpText, ExpText, lvlText;
    public PlayerHealthManager playerHP;
    public PlayerManaManager playerMP;
    private PlayerStats playerStats;

    private static bool UIExists;

    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        HpBar = GameObject.Find("HP_Bar").GetComponent<Slider>();
        MpBar = GameObject.Find("MP_Bar").GetComponent<Slider>();
        ExpBar = GameObject.Find("Exp_Bar").GetComponent<Slider>();

        HpText = GameObject.Find("HP_Text").GetComponent<Text>();
        MpText = GameObject.Find("MP_Text").GetComponent<Text>();
        ExpText = GameObject.Find("Exp_Text").GetComponent<Text>();
        lvlText = GameObject.Find("LvL_Text").GetComponent<Text>();

        playerHP = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
        playerMP = GameObject.Find("Player").GetComponent<PlayerManaManager>();

        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        HpBar.maxValue = playerHP.maxHP;
        HpBar.value = playerHP.currentHP;
        HpText.text = "HP: " + playerHP.currentHP + "/" + playerHP.maxHP;

        MpBar.maxValue = playerMP.maxMP;
        MpBar.value = playerMP.currentMP;
        MpText.text = "MP: " + playerMP.currentMP + "/" + playerMP.maxMP;

        if (playerStats.currentLvl < playerStats.expToLvlUp.Length)
        {

            ExpBar.maxValue = playerStats.expToLvlUp[playerStats.currentLvl];
            ExpText.text = "Exp: " + playerStats.currentExp + "/" + playerStats.expToLvlUp[playerStats.currentLvl];
            lvlText.text = "LvL: " + playerStats.currentLvl;
        }

        ExpBar.value = playerStats.currentExp;
        
    }
}