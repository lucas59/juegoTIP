using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoMovimiento : MonoBehaviour {

    Transform jugador; //Guarda la posicion del jugador
    NavMeshAgent IA;
    EnemigoVida enemigovida;
    JugadorVida jugadorvida;

    private void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        IA = GetComponent<NavMeshAgent>();

        jugadorvida = jugador.GetComponent<JugadorVida>();
        enemigovida = GetComponent<EnemigoVida>();
    }
    

    void Update()
    {
        if (enemigovida.obtenerVida > 0 && jugadorvida.obtenerVida > 0)
        {
            IA.SetDestination(jugador.position);
        }

        else
        {
            IA.enabled = false;
        }
    }
}
