using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoVida : MonoBehaviour {

    public int establecerVida = 100;
    public int obtenerVida;
    public float vHundimiento = 2.5f;
    public int valorPuntaje = 10;
    public AudioClip sonidoMuerte;
 public int empieza = 0;
    Animator anim;
    AudioSource audioEnemigo;
    ParticleSystem golpeParticulas;
    CapsuleCollider colliderEnemigo;
    bool estaMuerto;
    bool estaHundido;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioEnemigo = GetComponent<AudioSource>();
        golpeParticulas = GetComponentInChildren<ParticleSystem>();
        colliderEnemigo = GetComponent<CapsuleCollider>();
        obtenerVida = establecerVida;
    }

    private void Update()
    {
        if (estaMuerto)
        {
            transform.Translate(-Vector3.up * vHundimiento * Time.deltaTime);
        }

    }
    public void RecibirDamaged(int cantidad, Vector3 puntoGolpe)
    {
        if (estaMuerto)
            return;
        audioEnemigo.Play();
        obtenerVida -= cantidad;
        golpeParticulas.transform.position = puntoGolpe;
        golpeParticulas.Play();

        if (obtenerVida <= 0)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        estaMuerto = true;

        colliderEnemigo.isTrigger = true;
        anim.SetTrigger("EnemigoMuerte");
        audioEnemigo.clip = sonidoMuerte;
        audioEnemigo.Play();
        StartCoroutine(Example());
        EmpezarHundirme();
    }
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
    public void EmpezarHundirme()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        estaHundido = true;
        SistemadePuntaje.puntos += valorPuntaje;


        Destroy(gameObject, 2f);
    }
}

