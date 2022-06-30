using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaPuntaje : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TextoPuntaje;
    public int Puntaje = 0;

    private void Update()
    {
        DefPuntaje(Puntaje);
    }

    private void DefPuntaje(int Puntaje)
    {
        _TextoPuntaje.text = "SCORE " + Puntaje;
    }
    
}
