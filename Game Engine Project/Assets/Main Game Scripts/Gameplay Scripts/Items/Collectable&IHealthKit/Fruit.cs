using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //public int score;
    //Collectable fruit;

    

    private void Awake()
    {
        //fruit = new Collectable(1);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("A point earned");
            //ScoreManager.scoreManager.UpdateScore(score);
            //Debug.Log("Collided");
            //fruit.UpdateScore();
            AudioManager.instance.PlayOneShot(FMODEvents.instance.CoinCollected, this.transform.position);
            Inventory.inventory.nonConsumableItemsController.UseItem("Fruit");
            
            Destroy(gameObject);
        }
    }
}
