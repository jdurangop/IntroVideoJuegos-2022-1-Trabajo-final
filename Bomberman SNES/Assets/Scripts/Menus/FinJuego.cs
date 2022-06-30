using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour
{
    public void Reintentar()
    {
        SceneManager.LoadScene("Scenes/Nivel1");
    }
    
    public void Salir()
    {
        SceneManager.LoadScene("Scenes/Menu_Inicio");
    }
}
