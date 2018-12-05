using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAtaque : MonoBehaviour
{

    public float duracionAtaque = 0.5f;
    public int ataqueDamage = 10;
    
    Animator animaciones;
    GameObject jugador;
    JugadorVida jugadorVida;

    public bool estaAtacando;
    public float tiempo;

    void Awake()
    {
        animaciones = GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugadorVida = jugador.GetComponent<JugadorVida>();
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == jugador)
        {
            estaAtacando = true;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject == jugador)
        {
            estaAtacando = false;
        }
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        if(tiempo >= duracionAtaque && estaAtacando)
        {
            Atacar();
        }

        if(jugadorVida.obtenerVida <= 0)
        {
            animaciones.SetTrigger("EnemigoNeutral");
        }
    }

    void Atacar()
    {
        tiempo = 0f;
          animaciones.SetTrigger("EnemigoAtaque");
           animaciones.SetTrigger("EnemigoMover");
        
        if(jugadorVida.obtenerVida > 0)
        {
            jugadorVida.RecibirDamaged(ataqueDamage);
        }
    }
}
