using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemadeJefe : MonoBehaviour {
    public GameObject Enemigo2;
      public JugadorVida jugadorVida;
    public GameObject Jefe_1;
    public GameObject Jefe_2;
    public GameObject Jefe_3;
    public GameObject Jefe_4;
    public float tiempoSpawn = 3f;
    public Transform[] posicionSpawn;
    int stop = 0;
	void Update () {
		if(stop == 0 && Enemigo2.GetComponent<SistemadeEnemigo>().indice == 5){
            stop = 1;
            int spawnIndex = Random.Range(0, posicionSpawn.Length);
            Instantiate(Jefe_1, posicionSpawn[spawnIndex].position, posicionSpawn[spawnIndex].rotation);
            return;
        }
        if(stop == 1 && Enemigo2.GetComponent<SistemadeEnemigo>().indice == 10){
            stop = 2;
            int spawnIndex2 = Random.Range(0, posicionSpawn.Length);
            Instantiate(Jefe_2, posicionSpawn[spawnIndex2].position, posicionSpawn[spawnIndex2].rotation);
            return;
        }
         if(stop == 2 && Enemigo2.GetComponent<SistemadeEnemigo>().indice == 15){
            stop = 3;
            int spawnIndex2 = Random.Range(0, posicionSpawn.Length);
            Instantiate(Jefe_3, posicionSpawn[spawnIndex2].position, posicionSpawn[spawnIndex2].rotation);
            return;
        }
         if(stop == 3 && Enemigo2.GetComponent<SistemadeEnemigo>().indice == 20){ 
            stop = 4;
            int spawnIndex2 = Random.Range(0, posicionSpawn.Length);
            Instantiate(Jefe_4, posicionSpawn[spawnIndex2].position, posicionSpawn[spawnIndex2].rotation);
            return;
        }
	}
}
