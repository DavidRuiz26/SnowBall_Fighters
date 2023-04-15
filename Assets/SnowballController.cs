using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballController : MonoBehaviour
{
    public float throwForce = 10f; // Fuerza con la que se lanza la bola de nieve
    public string gripButtonName = "Grip"; // Nombre del bot�n de agarre

    private bool isHolding = false; // Si el jugador est� sosteniendo la bola de nieve
    private Rigidbody rb; // Rigidbody de la bola de nieve

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el Rigidbody del objeto
    }

    void Update()
    {
        if (isHolding) // Si el jugador est� sosteniendo la bola de nieve
        {
            // Mover la bola de nieve con el controlador VR del jugador
            transform.position = transform.parent.position;
            transform.rotation = transform.parent.rotation;

            // Soltar la bola de nieve si el jugador suelta el bot�n de agarre del controlador
            if (Input.GetAxisRaw(gripButtonName) == 0)
            {
                rb.isKinematic = false; // Permitir que la bola de nieve se mueva por la f�sica
                rb.AddForce(transform.forward * throwForce); // Lanzar la bola de nieve en la direcci�n en la que est� mirando el controlador
                isHolding = false; // El jugador ya no est� sosteniendo la bola de nieve
            }
        }
    }

    // Cuando el jugador colisiona con la bola de nieve
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el jugador toca la bola de nieve, la bola de nieve se vuelve kinem�tica
            // y se mueve con el controlador VR del jugador
            rb.isKinematic = true;
            transform.SetParent(other.transform);
            isHolding = true;
        }
    }

    // Cuando el jugador deja de colisionar con la bola de nieve
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el jugador deja de tocar la bola de nieve, la bola de nieve se vuelve no kinem�tica
            // y se desvincula del controlador VR del jugador
            rb.isKinematic = false;
            transform.SetParent(null);
            isHolding = false;
        }
    }
}