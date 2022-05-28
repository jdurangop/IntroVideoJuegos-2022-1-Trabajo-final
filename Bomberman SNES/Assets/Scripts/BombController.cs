using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    // Calls the properties of the prefab we have created of the bomb
    public GameObject bombPrefab;
    // Key that we have to press to detonate the bomb
    public KeyCode inputKey = KeyCode.Space;
    // How long does it take a bomb to explode?
    public float bombExplosionTime = 3f;
    // Quantity of bombs the player can deploy
    public int bombAmount = 1;
    // Remaining/Available bombs
    private int bombsRemaining;

    private void OnEnable()
    {
        // This sets the remaining bombs to the actual amount of bombs the player has for every
        // time the script runs
        bombsRemaining = bombAmount;
    }

    private void Update()
    {
        // If the player has bombs and the user press the space key, then drop the bomb
        if ( bombsRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            // Calls the function
            StartCoroutine(PlaceBomb());
        }
    }
    
    // Function for placing a bomb
    // This co-routine allows us to suspend the execution of the function over time
    private IEnumerator  PlaceBomb()
    {
        // Instantiating the bomb to the player's position
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        // Reducing the amount of bombs after dropping one
        bombsRemaining--;
        
        // Cooldown
        yield return new WaitForSeconds(bombExplosionTime);
        
        // Destroy the GameObject after the explosion
        Destroy(bomb);
        
        // Returning to the initial conditions
        bombsRemaining++;
    }
    
    // Making the bomb an actual collider with full physics interactions,
    // once the player has dropped it
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }
}
