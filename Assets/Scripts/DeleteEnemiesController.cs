using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeleteEnemiesController : MonoBehaviour
{
    private GameObject score;
    private GameObject spawnZone;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
        spawnZone = GameObject.FindGameObjectWithTag("SpawnZone");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            score.GetComponent<ScoreController>().UpdateScore();
            spawnZone.GetComponent<SpawnZone>().DecreaseNumberOfEnemies();
            Destroy(gameObject);
            Destroy(collision.gameObject);

            if (spawnZone.GetComponent<SpawnZone>().CheckNumberOfEnemies() == 0)
            {
                spawnZone.GetComponent<SpawnZone>().GenerateNewWave();
            }
        }
    }
}
