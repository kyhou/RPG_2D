using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damage;
    public GameObject damageBurst, damageNumber;

    private PlayerStats playerStats;
    private int currentDamage;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            currentDamage = damage - playerStats.currentDefence;
            if(currentDamage < 0)
            {
                currentDamage = 0;
            }
            
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            Instantiate(damageBurst, other.gameObject.transform.position, other.gameObject.transform.rotation);

            var clone = (GameObject)Instantiate(damageNumber, other.gameObject.transform.position, Quaternion.Euler(Vector3.zero)); //other.gameObject.transform.rotation);
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}