using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Item item;
    private string data, stats1, stats2;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item)
    {
        this.item = item;
        ContructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ContructDataString()
    {
        stats1 = "";
        stats2 = "";

        if (item.Attack != 0)
        {
            stats1 += "Attack:" + item.Attack + "\n";
        }

        if (item.Defense != 0)
        {
            stats1 += "Defense:" + item.Defense + "\n";
        }

        if (item.Power != 0)
        {
            stats2 += "Power:" + item.Power + "\n";
        }

        if (item.Agility != 0)
        {
            stats2 += "Agility:" + item.Agility + "\n";
        }

        if (item.Vitality != 0)
        {
            stats2 += "Vitality:" + item.Vitality + "\n";
        }

        if (item.Inteligence != 0)
        {
            stats2 += "Inteligence:" + item.Inteligence + "\n";
        }

        if (item.Constitution != 0)
        {
            stats2 += "Constitution:" + item.Constitution + "\n";
        }

        data = "<color=#000000><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n\n";

        if (stats1 != null)
            data += stats1 + "\n";

        if (stats2 != null)
            data += stats2;

        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
