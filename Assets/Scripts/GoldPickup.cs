using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;
    public MoneyManager money;

    void Start()
    {
        money = FindObjectOfType<MoneyManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            money.AddMoney(value);
            Destroy(gameObject);
        }
    }
}