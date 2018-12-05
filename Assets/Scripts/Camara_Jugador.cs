﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Jugador : MonoBehaviour {

    public GameObject jugador;
    public GameObject Referencia;
    private Vector3 distancia;


	void Start () {
        distancia = transform.position - jugador.transform.position;
	}
	
	
	void LateUpdate () {
        distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distancia;

        transform.position = jugador.transform.position + distancia;

        transform.LookAt(jugador.transform.position);

        //Referencia para que los controles no cambien

        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y, 0);
        Referencia.transform.eulerAngles = copiaRotacion;
	}
}
