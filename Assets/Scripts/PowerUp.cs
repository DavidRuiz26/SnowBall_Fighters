using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject bola; 
    private GameObject spawnZone;

    void Start()
    {
        spawnZone = GameObject.FindGameObjectWithTag("SpawnZone");

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            var target = GameObject.FindGameObjectWithTag("Head");
            Instantiate(bola, target.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("BigBall"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            var target = GameObject.FindGameObjectWithTag("Head");
            Instantiate(bola, target.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            spawnZone.GetComponent<SpawnZone>().SpawnGoal();
        }
    }
}
