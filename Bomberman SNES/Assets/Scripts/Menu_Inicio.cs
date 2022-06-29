using UnityEngine;
using UnityEngine.SceneManagement;

internal class Menu_Inicio : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel 1");
    }
    
    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}
