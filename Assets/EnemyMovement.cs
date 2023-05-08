using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 0.75f; // Velocidad del movimiento
    public float distance = 5f; // Distancia máxima que el objeto se moverá de su posición inicial

    private Vector3 startPosition; // Posición inicial del objeto
    private float direction = 1f; // Dirección del movimiento, 1 es derecha, -1 es izquierda

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial del objeto
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la nueva posición del objeto
        Vector3 newPosition = startPosition + new Vector3(Mathf.Sin(Time.time * speed), 0, 0) * distance;

        // Si el objeto llega al límite de su movimiento, cambia de dirección
        if (Mathf.Abs(newPosition.x - startPosition.x) > distance)
        {
            direction *= -1f;
            newPosition = transform.position + new Vector3(speed * direction * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.FromToRotation(transform.rotation.eulerAngles, new Vector3(0, transform.rotation.y + 180));
            transform.localScale = new Vector3(direction, 1f, 1f); // Voltea el modelo
        }

        // Asigna la nueva posición al objeto
        transform.position = newPosition;
    }
}
