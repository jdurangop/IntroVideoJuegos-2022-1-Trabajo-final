using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Destructible : MonoBehaviour

{
    public float destructionTime = 1f;
    
    // Range for selecting the spawn chance value
    [Range(0f, 1f)]
    // Spawn chance of an item
    public float itemSpawnChance = 0.3f;
    // Objects that are able to be spawned
    public GameObject[] spawnableItems;

    private void Start()
    {
        Destroy(gameObject,destructionTime);
    }
    
    // Once the destructible object has been destroyed, then spawn the item with its probability 
    private void OnDestroy()
    {
        if (spawnableItems.Length > 0 && Random.value < itemSpawnChance)
        {
            int randomIndex = Random.Range(0, spawnableItems.Length);
            Instantiate(spawnableItems[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
