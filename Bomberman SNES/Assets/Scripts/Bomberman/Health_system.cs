using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_system : MonoBehaviour
{
    //Sistema de vida del Bomberman
    
    [SerializeField] private int health = 2;
    public bool invencible = false;
    public float time_invencible = 3f;


    public void TakeDamage()

    {
        if (!invencible)
        {
            
            StartCoroutine(Inmunity());
            health--;
            if (health <= 0)
            {
                gameObject.SetActive(false); 
            }
        }
    }
    
    IEnumerator Inmunity()
    {
        Debug.Log("timer");
        invencible = true;
        yield return new WaitForSeconds(time_invencible);
        invencible = false;
    }

}
