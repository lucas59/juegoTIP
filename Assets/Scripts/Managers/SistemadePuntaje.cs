using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemadePuntaje : MonoBehaviour {
    public static int puntos;
    Text texto;


    private void Awake()
    {
        texto = GetComponent<Text>();
        puntos = 0;


    }

    private void Update()
    {
        texto.text = "Puntaje: " + puntos;
    }

}
