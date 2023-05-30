using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraBorraArboles : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(collision.gameObject);
        }
    }
}
