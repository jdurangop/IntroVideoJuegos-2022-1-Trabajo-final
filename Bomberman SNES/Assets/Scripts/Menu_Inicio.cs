using UnityEngine;
using UnityEngine.SceneManagement;

internal class Menu_Inicio : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
        Time.timeScale = 1f;
    }
    
    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}
