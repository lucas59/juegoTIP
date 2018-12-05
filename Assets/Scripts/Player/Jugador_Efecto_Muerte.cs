using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Efecto_Muerte : MonoBehaviour {
    public ParticleSystem particulas_Muerte;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void ActivarAura(){
        particulas_Muerte.Play();
    }
}
