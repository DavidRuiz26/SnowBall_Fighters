using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeleteEnemyBallController : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Valla"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Head"))
        {
            Destroy(gameObject);
            player.GetComponent<HPSystem>().PerderVida();
            audioSource.PlayOneShot(bonk);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

