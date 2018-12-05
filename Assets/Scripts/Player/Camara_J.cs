using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_J: MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public GameObject referencia;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis ("Horizontal");
        float moverVertical = Input.GetAxis ("Vertical");

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        rb.AddForce(moverVertical * referencia.transform.forward * speed);
        rb.AddForce(moverHorizontal * referencia.transform.right * speed);
    }
}
