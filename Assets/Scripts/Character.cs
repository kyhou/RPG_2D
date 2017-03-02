using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    GameObject characterPanel;
    PlayerStats playerStats;

    public Text playerName, playerRace, playerLvl, playerClass, playerHp, playerMp, playerSta, playerAttack, playerDefence,
           playerPower, playerAgility, playerVitality, playerInteligence, playerConstituition, playerSp, powerTempMod, agilityTempMod, vitalityTempMod, inteligenceTempMod, constituitionTempMod, spTempMod;

    private GameObject powerUp, powerDown, agilityUp, agilityDown, vitalityUp, vitalityDown, inteligenceUp, inteligenceDown, constituitionUp, constituitionDown, finish;
    private int sp;

    void Start()
    {

        playerStats = GetComponent<PlayerStats>();

        characterPanel = GameObject.Find("Character Panel");

        powerUp = GameObject.Find("PowerUP");
        powerDown = GameObject.Find("PowerDown");
        agilityUp = GameObject.Find("AgilityUP");
        agilityDown = GameObject.Find("AgilityDown");
        vitalityUp = GameObject.Find("VitalityUP");
        vitalityDown = GameObject.Find("VitalityDown");
        inteligenceUp = GameObject.Find("InteligenceUP");
        inteligenceDown = GameObject.Find("InteligenceDown");
        constituitionUp = GameObject.Find("ConstitutionUP");
        constituitionDown = GameObject.Find("ConstitutionDown");
        finish = GameObject.Find("Finish");

        playerName = GameObject.Find("Name").GetComponent<Text>();
        playerRace = GameObject.Find("Race").GetComponent<Text>();
        playerLvl = GameObject.Find("Level").GetComponent<Text>();
        playerClass = GameObject.Find("Class").GetComponent<Text>();
        playerHp = GameObject.Find("HP").GetComponent<Text>();
        playerMp = GameObject.Find("MP").GetComponent<Text>();
        playerSta = GameObject.Find("Sta").GetComponent<Text>();
        playerAttack = GameObject.Find("Attack").GetComponent<Text>();
        playerDefence = GameObject.Find("Defence").GetComponent<Text>();
        playerPower = GameObject.Find("Power").GetComponent<Text>();
        playerAgility = GameObject.Find("Agility").GetComponent<Text>();
        playerVitality = GameObject.Find("Vitality").GetComponent<Text>();
        playerInteligence = GameObject.Find("Inteligence").GetComponent<Text>();
        playerConstituition = GameObject.Find("Constituition").GetComponent<Text>();
        playerSp = GameObject.Find("SP").GetComponent<Text>();

        powerTempMod = GameObject.Find("PowerTempMod").GetComponent<Text>();
        agilityTempMod = GameObject.Find("AgilityTempMod").GetComponent<Text>();
        vitalityTempMod = GameObject.Find("VitalityTempMod").GetComponent<Text>();
        inteligenceTempMod = GameObject.Find("InteligenceTempMod").GetComponent<Text>();
        constituitionTempMod = GameObject.Find("ConstituitionTempMod").GetComponent<Text>();
        spTempMod = GameObject.Find("SpTempMod").GetComponent<Text>();

        playerName.text = "Name: " + playerStats.name;
        playerRace.text = "Race: " + playerStats.race;
        playerLvl.text = "Level: " + playerStats.currentLvl;
        playerClass.text = "Class: " + playerStats.pClass;
        playerHp.text = "HP: " + playerStats.currentHp;
        playerMp.text = "MP: " + playerStats.currentMp;
        playerSta.text = "Sta: " + playerStats.currentSta;
        playerAttack.text = "Attack: " + playerStats.currentAttack;
        playerDefence.text = "Defence: " + playerStats.currentDefence;
        playerPower.text = "Power: " + playerStats.currentPower;
        playerAgility.text = "Agility: " + playerStats.currentAgi;
        playerVitality.text = "Vitality: " + playerStats.currentVit;
        playerInteligence.text = "Inteligence: " + playerStats.currentInt;
        playerConstituition.text = "Constituition: " + playerStats.currentConst;
        playerSp.text = "SP: " + playerStats.statsPoints;

        powerTempMod.text = "";
        agilityTempMod.text = "";
        vitalityTempMod.text = "";
        inteligenceTempMod.text = "";
        constituitionTempMod.text = "";
        spTempMod.text = "";

        sp = playerStats.statsPoints;

        deactivateStatsButtons();
        characterPanel.SetActive(false);
    }

    void Update()
    {
        if(sp > 0)
        {
            activateStatsButtons();
        }
        else
        {
            deactivateStatsButtons();
        }
    }

    public void activateStatsButtons()
    {
        powerUp.gameObject.SetActive(true);
        powerDown.gameObject.SetActive(true);
        agilityUp.gameObject.SetActive(true);
        agilityDown.gameObject.SetActive(true);
        vitalityUp.gameObject.SetActive(true);
        vitalityDown.gameObject.SetActive(true);
        inteligenceUp.gameObject.SetActive(true);
        inteligenceDown.gameObject.SetActive(true);
        constituitionUp.gameObject.SetActive(true);
        constituitionDown.gameObject.SetActive(true);
        finish.gameObject.SetActive(true);
    }

    public void deactivateStatsButtons()
    {
        powerUp.gameObject.SetActive(false);
        powerDown.gameObject.SetActive(false);
        agilityUp.gameObject.SetActive(false);
        agilityDown.gameObject.SetActive(false);
        vitalityUp.gameObject.SetActive(false);
        vitalityDown.gameObject.SetActive(false);
        inteligenceUp.gameObject.SetActive(false);
        inteligenceDown.gameObject.SetActive(false);
        constituitionUp.gameObject.SetActive(false);
        constituitionDown.gameObject.SetActive(false);
        finish.gameObject.SetActive(false);
    }

    public void StatsActualization()
    {
        playerStats.StatsActualization();
        playerName.text = "Name: " + playerStats.name;
        playerRace.text = "Race: " + playerStats.race;
        playerLvl.text = "Level: " + playerStats.currentLvl;
        playerClass.text = "Class: " + playerStats.pClass;
        playerHp.text = "HP: " + playerStats.currentHp;
        playerMp.text = "MP: " + playerStats.currentMp;
        playerSta.text = "Sta: " + playerStats.currentSta;
        playerAttack.text = "Attack: " + playerStats.currentAttack;
        playerDefence.text = "Defence: " + playerStats.currentDefence;
        playerPower.text = "Power: " + playerStats.currentPower;
        playerAgility.text = "Agility: " + playerStats.currentAgi;
        playerVitality.text = "Vitality: " + playerStats.currentVit;
        playerInteligence.text = "Inteligence: " + playerStats.currentInt;
        playerConstituition.text = "Constituition: " + playerStats.currentConst;
        playerSp.text = "SP: " + playerStats.statsPoints;
        sp = playerStats.statsPoints;
    }
}