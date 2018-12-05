using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {


    public JugadorVida jugadorVida;
    public float reiniciarNivel = 5f;

    Animator animaciones;
    float tiempoReinicio;

    private void Awake()
    {
        animaciones = GetComponent<Animator>();
    }

    private void Update()
    {
        if(jugadorVida.obtenerVida <= 0)
        {
            animaciones.SetTrigger("GameOver");
            tiempoReinicio = Time.deltaTime;

            if(tiempoReinicio > reiniciarNivel)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
