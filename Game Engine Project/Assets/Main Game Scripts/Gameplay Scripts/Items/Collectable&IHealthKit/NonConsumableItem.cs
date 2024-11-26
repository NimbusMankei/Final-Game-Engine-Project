using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonConsumableItem : Item
{
    public NonConsumableItem(string name, int worth)
    {
        itemName = name;
        itemWorth = worth;
    }

    public override void Use()
    {
        ScoreManager.scoreManager.UpdateScore(itemWorth);
        Debug.Log($"Item {itemName} is used.");
    }

    public void UnEquip()
    {
        ScoreManager.scoreManager.UpdateScore(-itemWorth);
        Debug.Log($"Item {itemName} is unequipped.");
    }
}
