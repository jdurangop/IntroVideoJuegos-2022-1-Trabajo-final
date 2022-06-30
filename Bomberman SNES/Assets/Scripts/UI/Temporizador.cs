using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextoTemp;
    public float Temp;
    private bool Interruptor = true;

    private void Update()
    {
        if (Interruptor)
        {
            Temp -= Time.deltaTime;
            if (Temp < 0)
            {
                Interruptor = false;
                SceneManager.LoadScene("Scenes/Game Over");
            }
        }
        
        TextoTemp.text = "TIEMPO:" + Temp.ToString("f0");
    }
}
 