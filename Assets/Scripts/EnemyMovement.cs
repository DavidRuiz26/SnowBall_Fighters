using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 0.75f; // Velocidad del movimiento
    public float distance = 5f; // Distancia máxima que el objeto se moverá de su posición inicial

    private Quaternion targetRotation;
    private Vector3 startPosition; // Posición inicial del objeto
    private Vector3 finishPosition; //Finish position of the object

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial del objeto
        finishPosition = new Vector3(startPosition.x+5, startPosition.y, startPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la nueva posición del objeto
        Vector3 newPosition = startPosition + new Vector3(Mathf.Sin(Time.time * speed), 0, 0) * distance;

        if(newPosition == finishPosition){
            targetRotation = Quaternion.Euler(0, 180, 0); // Gira 180 grados en el eje Y
            transform.rotation = targetRotation; // Aplica la rotación al objeto
        }

        // Asigna la nueva posición al objeto
        transform.position = newPosition;
    }

}
