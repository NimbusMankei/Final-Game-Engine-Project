using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{
     public ConsumableItem(string name, int worth, int currentlyOwnedQuantity)
    {
        itemName = name;
        itemWorth = worth;
        ownedQuantity = currentlyOwnedQuantity;
    }   

    public override void Use()
    {
        ownedQuantity--;
        PlayerManager.playermanager.player.GetComponent<PlayerInventoryStats>().RestoreHealth(itemWorth);
        Debug.Log($"Item {itemName} is used. Now remaining {GetOwnedQuantity()}");
    }
}
