using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    //private Collectable heart;

    private void Start()
    {
        //eart = new Collectable("heart", 0, 5);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            //heart.UpdateHealth();
            Inventory.inventory.consumableItemsController.GetItem("HealthPill").PurchaseItem();
            //UseItem("First-Aid Kit");
            Destroy(gameObject);
        }
    }
}
