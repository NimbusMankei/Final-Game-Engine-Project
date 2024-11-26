using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string nameCollectable;
    
    public int score;

    public int restoreHealth;

   public Collectable(string name, int scorevalue, int restoreHPV)
   {
    this.nameCollectable = name;
    this.score = scorevalue;
    this.restoreHealth = restoreHPV;
   }

    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(score);
    }

    public void UpdateHealth()
    {
        PlayerManager.playermanager.player.GetComponent<PlayerInventoryStats>().RestoreHealth(this.restoreHealth);
    }

}
