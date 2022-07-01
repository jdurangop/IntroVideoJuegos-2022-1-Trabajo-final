using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class SistemaPuntaje : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TextoPuntaje;
    public int _PuntajeTotal = 0;

    private void Start()
    {
        Events.OnEnemyDeathEvent += DefPuntaje;
    }

    private void OnDestroy()
    {
        Events.OnEnemyDeathEvent -= DefPuntaje;
    }
    
    private void DefPuntaje(int Puntaje)
    {
        _PuntajeTotal += Puntaje;
        _TextoPuntaje.text = "Puntaje: " + _PuntajeTotal;
    }
    
}
