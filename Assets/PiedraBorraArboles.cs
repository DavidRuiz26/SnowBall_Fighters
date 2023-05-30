using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraBorraArboles : MonoBehaviour
{
    private int rompe= 0; 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(collision.gameObject);
            rompe++; 
        }
        if (rompe == 3)
        {
            Destroy(gameObject); 
        }

    }
}
