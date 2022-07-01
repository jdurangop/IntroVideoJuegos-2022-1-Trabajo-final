using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
        
        EnemyMovement enemy = other.transform.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.TakeDamage();
        }
        
        BombController bomberman = other.transform.GetComponent<BombController>();
        if (bomberman != null)
        {
            bomberman.TakeDamage();
        }
        
        ItemPickUp powerup = other.transform.GetComponent<ItemPickUp>();
        if (powerup != null)
        {
            powerup.TakeDamage();
        }
        
    }
    
}
