using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    // Calls the properties of the prefab we have created for the bomb
    public GameObject bombPrefab;
    // Key that we have to press to detonate the bomb
    public KeyCode inputKey = KeyCode.Space;
    // How long does it take a bomb to explode?
    public float bombExplosionTime = 3f;
    // Quantity of bombs the player can deploy
    public int bombAmount = 1;  // POWER UP
    // Remaining/Available bombs
    private int bombsRemaining;
    
    [Header("Explosion")]
    // Calls the properties of the prefab we have created for the explosion
    public Explosion explosionPrefab;
    //Capa de explosión
    public LayerMask explosionLayerMask;
    // Duration time of the explosion
    public float explosionDuration = 1f;
    // Radius of the explosion
    public int explosionRadius = 1; // POWER UP

    [Header("Destructible")] 
    //
    public Tilemap destructibleTiles;
    public Destructible destructiblePrefab;
    
    
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
        
        // Instantiating the explosion game object at the position of the bomb
        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);
        // Destroying the explosion game object after a certain amount of time
        explosion.DestroyAfter(explosionDuration);
        
        // Calling the Explode function
        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);
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
    
    // This function help us to make the explosion to take more than one tile and in a radius
    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        // Exit condition
        if (length <= 0)
        {
            return;
        }
        
        position += direction;

        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            ClearDestructible(position);
            return;
        }
        
        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(length > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionDuration);
        
        // The step when the function becomes recursive
        Explode(position, direction, length - 1);
    }
    
    // This function adds the extra bomb once the player has picked the item up
    public void AddBomb()
    {
        bombAmount++;
        bombsRemaining++;
    }

    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if (tile != null)
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell,null);
        }
    }
    
    
    //Sistema de vida del Bomberman
    
    [SerializeField] private int health = 2;

    public void TakeDamage()

    {
        health--;
        if (health < 0)
        {
            gameObject.SetActive(false); 
        }
    }
    
}
