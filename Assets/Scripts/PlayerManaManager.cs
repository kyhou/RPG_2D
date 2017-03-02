using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaManager : MonoBehaviour
{
    public int maxMP, currentMP;

    private PlayerStats playerStats;
    private SFXManager sfxManager;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>();

        maxMP = playerStats.currentMp;
        SetMaxMP();

        sfxManager = FindObjectOfType<SFXManager>();
    }

    void Update()
    {
        /*if (currentMP <= 0)
        {
            sfxManager.playerDead.Play();
            gameObject.SetActive(false);
        }*/
    }

    /*public void HurtPlayer(int damageToGive)
    {
        currentMP -= damageToGive;
        sfxManager.playerHurt.Play();
    }*/

    public void SetMaxMP()
    {
        currentMP = maxMP;
    }
}