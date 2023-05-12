using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DeleteEnemiesController : MonoBehaviour
{
    private GameObject score;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            score.GetComponent<ScoreController>().UpdateScore();

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
