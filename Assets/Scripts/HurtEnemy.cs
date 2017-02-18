using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = damage + playerStats.currentAttack;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, other.gameObject.transform.position, other.gameObject.transform.rotation);

            var clone = (GameObject)Instantiate(damageNumber, other.gameObject.transform.position, Quaternion.Euler(Vector3.zero)); //other.gameObject.transform.rotation);
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
