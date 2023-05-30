using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacion : MonoBehaviour
{
    private GameObject player;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip bonk;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            Destroy(gameObject);
            player.GetComponent<HPSystem>().GanarVida();
            audioSource.PlayOneShot(bonk);
        }
        if (collision.gameObject.CompareTag("BigBall"))
        {
            Destroy(gameObject);
            player.GetComponent<HPSystem>().GanarVida();
            audioSource.PlayOneShot(bonk);
        }
    }
}
