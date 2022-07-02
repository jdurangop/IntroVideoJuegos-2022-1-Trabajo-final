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
        
        EnemyManage enemy = other.transform.GetComponent<EnemyManage>();
        if (enemy != null)
        {
            enemy.TakeDamage();
        }
        
        Health_system bomberman = other.transform.GetComponent<Health_system>();
        if (bomberman != null)
        {
             bomberman.TakeDamage();
        }
               
        
        ItemPickUp powerup = other.transform.GetComponent<ItemPickUp>();
        if (powerup!= null)
        {
            powerup.TakeDamage();
        }

    }

    
}
