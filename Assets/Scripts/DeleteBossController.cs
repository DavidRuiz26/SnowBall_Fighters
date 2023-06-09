using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeleteBossController : MonoBehaviour
{
    private GameObject score;
    private GameObject spawnZone;
    private int contador = 0; 

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
        spawnZone = GameObject.FindGameObjectWithTag("SpawnZone");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            contador = contador + 1;
            var numberOfEnemies = spawnZone.GetComponent<SpawnZone>().CheckNumberOfEnemies();
            if (contador == 5)
            {
                score.GetComponent<ScoreController>().UpdateScore();
                spawnZone.GetComponent<SpawnZone>().DecreaseNumberOfEnemies();

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            

            if (numberOfEnemies == 0)
            {
                spawnZone.GetComponent<SpawnZone>().GenerateNewWave();
            }
        }
    }
}
