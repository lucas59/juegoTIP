using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Jugador : MonoBehaviour {

  
    public float velocidad = 6f;
    Vector3 movimiento;
    Animator animaciones;
    Rigidbody rigidabody;
    int capaSuelo;
    float Raylongitud = 100f;

    void Awake()
    {
        animaciones = GetComponent<Animator>();
        rigidabody = GetComponent<Rigidbody>();
        capaSuelo = LayerMask.GetMask("Floor");
    }

        void FixedUpdate()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Movimiento(h,v);
            RotacionJugador();
            Animaciones(h,v);
          
        }
   

    void Movimiento(float h, float v)
    {
        movimiento.Set(h, 0f, v);
        movimiento = movimiento.normalized * velocidad * Time.deltaTime;
        rigidabody.MovePosition(transform.position + movimiento);


    }
    void RotacionJugador()
    {
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit golpe;
        if(Physics.Raycast(laser,out golpe, Raylongitud, capaSuelo))
        {
            Vector3 mousePosicion = golpe.point - transform.position;
            mousePosicion.y = 0f;

            Quaternion rotacionjugador = Quaternion.LookRotation(mousePosicion);
            rigidabody.MoveRotation(rotacionjugador);
        }
    }

 
      
            
          
       //690
    void Animaciones(float h, float v)
    {
        Vector3 posicion_mouse = Input.mousePosition;
        bool boton_s_mouse_atras = (v == -1f) && (posicion_mouse.y < 266);//si le da al boton "s" y el mouse esta abajo del "Player" = true
        bool boton_w_mouse_atras = (v == 1f) && (posicion_mouse.y < 266);//si le da al boton "w" y el mouse esta abajo del "Player" = true
        bool boton_s_mouse_adelante = (v == -1f) && (posicion_mouse.y > 266); //si le da al boton "s" y el mouse esta arriba del "Player" = true
        bool boton_w_mouse_adelante = (v == 1f) && (posicion_mouse.y > 266); //si le da al boton "w" y el mouse esta arriba del "Player" = true
        bool movimiento_Derecha_A_mouse_Atras = (h == -1f) && (posicion_mouse.y < 266);
        bool movimiento_Izquierda_D_mouse_Atras = (h == 1f) && (posicion_mouse.y < 266);
        bool movimiento_Izquierda_A_mouse_Adelante = (h == -1f) && (posicion_mouse.y > 266);
        bool movimiento_Derecha_D_mouse_Adelante = (h == 1f) && (posicion_mouse.y > 266);


        animaciones.SetBool("Esta_Caminando_Atras_S", boton_s_mouse_adelante);
        animaciones.SetBool("Esta_Caminando_Atras_W", boton_w_mouse_atras);
        animaciones.SetBool("Esta_Caminando_Adelante_S", boton_s_mouse_atras);
        animaciones.SetBool("Esta_Caminando_Adelante_W", boton_w_mouse_adelante);
        animaciones.SetBool("Esta_Caminando_Izquierda_A", movimiento_Izquierda_A_mouse_Adelante);
        animaciones.SetBool("Esta_Caminando_Derecha_D", movimiento_Derecha_D_mouse_Adelante);
        animaciones.SetBool("Esta_Caminando_Izquierda_D", movimiento_Izquierda_D_mouse_Atras);
        animaciones.SetBool("Esta_Caminando_Derecha_A", movimiento_Derecha_A_mouse_Atras);
    }
    
    }
