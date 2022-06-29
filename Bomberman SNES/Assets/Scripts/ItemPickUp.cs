using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // This type of variable allows us to have an enumerated list of names
    public enum ItemType
    {
        BlastRadius,
        ExtraBomb,
        SpeedIncrease
        
    }
    
    // Declaring a variable to hold the item type
    public ItemType type;
    
    // This function basically applies the POWER UP to the player set up
    private void OnItemPickUp(GameObject player)
    {
        switch (type)
        {
            case ItemType.BlastRadius:
                player.GetComponent<BombController>().explosionRadius++;
                break;
            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                break;
            case ItemType.SpeedIncrease:
                player.GetComponent<Movement>().speed++;
                break;
        }
        
        Destroy(gameObject);
    }

    // This built-in function detects if the player has picked the power up (item) up or not
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickUp(other.gameObject);
        }
    }
}
