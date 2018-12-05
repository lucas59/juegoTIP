using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemadeEnemigo : MonoBehaviour
{
    public JugadorVida jugadorVida;
    public GameObject enemigo;
    public float tiempoSpawn = 3f;
    public Transform[] posicionSpawn;
    public int indice = 0;

    private void Start()
    {
        InvokeRepeating("Spawn", tiempoSpawn, tiempoSpawn);
    }

    void Spawn()
    {
        if(jugadorVida.obtenerVida <= 0f)
        {
            return;
        }
        if(indice == 21){
            return;
        }

        int spawnIndex = Random.Range(0, posicionSpawn.Length);
        indice = indice + 1;
        Instantiate(enemigo, posicionSpawn[spawnIndex].position, posicionSpawn[spawnIndex].rotation);

    }

}