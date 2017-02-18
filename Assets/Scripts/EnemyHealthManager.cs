using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHP, currentHP, exp;
    public string enemyQuestName;

    private PlayerStats playerStats;
    private QuestManager questManager;

    void Start()
    {
        currentHP = maxHP;
        playerStats = FindObjectOfType<PlayerStats>();
        questManager = FindObjectOfType<QuestManager>();
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            questManager.enemyKilled = enemyQuestName;
            Destroy(gameObject);
            playerStats.AddExp(exp);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHP -= damageToGive;
    }

    public void SetMaxHP()
    {
        currentHP = maxHP;
    }
}