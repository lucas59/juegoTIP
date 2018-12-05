using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JugadorVida : MonoBehaviour {

    public GameObject Jugador;
    public ParticleSystem particulas_Muerte;
    public int establecerVida = 100;
    public int obtenerVida;
    public Slider barraVida;
    public Image efectoDamage;
    public AudioClip sonidoDamage;
    public float velocidadFlash = 5f;
    public Color colorFlash = new Color(1f, 0f, 0f, 0.1f);

    Animator animaciones;
    AudioSource sonidoJugador;
    Movimiento_Jugador jugadorMovimiento;

    bool estaMuerto;
    bool damaged;

    void Awake()
    {
        animaciones = GetComponent<Animator>();
        sonidoJugador = GetComponent<AudioSource>();
        jugadorMovimiento = GetComponent<Movimiento_Jugador>();
        

        obtenerVida = establecerVida;

    }

    void Update()
    {
        if (damaged)
        {
            efectoDamage.color = colorFlash;
        }

        else
        {
            efectoDamage.color = Color.Lerp(efectoDamage.color, Color.clear, velocidadFlash * Time.deltaTime);
        }

        damaged = false;

    }

    public void RecibirDamaged(int cantidad)
    {
        damaged = true;
        obtenerVida -= cantidad;
        barraVida.value = obtenerVida;
        sonidoJugador.Play();

        if (obtenerVida <= 0 && !estaMuerto)
        {
            Muerte();
        }
    }


    void Muerte()
    {
        estaMuerto = true;
        animaciones.SetTrigger("EstaMuerto");
        sonidoJugador.clip = sonidoDamage;
        sonidoJugador.Play();
        jugadorMovimiento.enabled = false;
        gameObject.SetActive(true);
        particulas_Muerte.Play();
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    
}
