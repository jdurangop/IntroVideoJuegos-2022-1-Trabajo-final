using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To be able to load the scene to the game
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Possibility to name the level with the number or the string name of the particular scene
    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false;

    // This function detects if the player has collided with the teleport object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    // Loading the scene
    void LoadScene()
    {
        if (useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
