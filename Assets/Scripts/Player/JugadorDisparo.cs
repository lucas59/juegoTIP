using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDisparo : MonoBehaviour {

    public int ataqueDamage = 20;
    public float tiempoDisparo = 0.15f;
    public float distancia = 100f;
    float tiempo;
    Ray lineaDisparo;
    RaycastHit golpeDisparo;
    int capaEnemigo;
    ParticleSystem ParticulasDisparo;
    LineRenderer efectoDisparo;
    AudioSource sonidoDisparo;
    Light iluminacionDisparo;
    float tiempoEfecto = 0.2f;

    private void Awake()
    {
        capaEnemigo = LayerMask.GetMask("Shootable");

        ParticulasDisparo = GetComponent<ParticleSystem>();
        efectoDisparo = GetComponent<LineRenderer>();
        sonidoDisparo = GetComponent<AudioSource>();
        iluminacionDisparo = GetComponent<Light>();
    }

    private void Update()
    {
        tiempo += Time.deltaTime;
        if (Input.GetButton("Fire1") && tiempo >= tiempoDisparo) //Si esta precionado el boton de click
        {
            Disparo();
        }

        if(tiempo >= tiempoDisparo * tiempoEfecto)
        {
            EfectoDisparo();
        }
    }

    void Disparo()
    {
        tiempo = 0f;
        sonidoDisparo.Play();
        iluminacionDisparo.enabled = true;

        ParticulasDisparo.Stop();
        ParticulasDisparo.Play();

        efectoDisparo.enabled = true;
        efectoDisparo.SetPosition(0,transform.position);

        lineaDisparo.origin = transform.position;
        lineaDisparo.direction = transform.forward;

        if (Physics.Raycast(lineaDisparo, out golpeDisparo,distancia,capaEnemigo))
        {
            EnemigoVida enemigoVida = golpeDisparo.collider.GetComponent<EnemigoVida>();

            if(enemigoVida != null)
            {
                enemigoVida.RecibirDamaged(ataqueDamage, golpeDisparo.point);
            }

            efectoDisparo.SetPosition(1, golpeDisparo.point);


        }
        else
        {
            efectoDisparo.SetPosition(1, lineaDisparo.origin + lineaDisparo.direction * distancia);
        }
    }

    void EfectoDisparo()
    {
        iluminacionDisparo.enabled = false;
        efectoDisparo.enabled = false;
    }

}
