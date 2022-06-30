using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_pausa : MonoBehaviour
{
    [SerializeField] private GameObject BotonPausa;
    [SerializeField] private GameObject MenuPausa;
    private bool JuegoPausa = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausa)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        JuegoPausa = true;
        Time.timeScale = 0f;
        BotonPausa.SetActive(false);
        MenuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        JuegoPausa = false;
        Time.timeScale = 1f;
        BotonPausa.SetActive(true);
        MenuPausa.SetActive(false);
    }

    public void Salir()
    {
        SceneManager.LoadScene("Scenes/Menu_Inicio");
    }
    
    public void Reiniciar()
    {
        JuegoPausa = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
