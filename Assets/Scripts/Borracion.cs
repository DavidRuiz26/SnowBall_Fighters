using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borracion : MonoBehaviour
{
    
    private GameObject spawnZone;

    void Start()
    {
        
        spawnZone = GameObject.FindGameObjectWithTag("SpawnZone");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piedra"))
        {

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
