using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacion : MonoBehaviour
{
    private GameObject player;

    private AudioSource audioSource;
    private GameObject spawnZone;

    [SerializeField]
    private AudioClip bonk;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnZone = GameObject.FindGameObjectWithTag("SpawnZone");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            player.GetComponent<HPSystem>().GanarVida();
            audioSource.PlayOneShot(bonk);
        }
        if (collision.gameObject.CompareTag("BigBall"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            player.GetComponent<HPSystem>().GanarVida();
            audioSource.PlayOneShot(bonk);
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            spawnZone.GetComponent<SpawnZone>().SpawnGoal();
        }
    }
}
