using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // Determine which item the user picked up
    // This type of variable allows us to have an enumerated list of names
    public enum ItemType
    {
        BlastRadius,
        ExtraBomb,
        SpeedIncrease
        
    }
    
    // Declaring a variable to hold the item type
    public ItemType type;
}
