using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SpawnZone : MonoBehaviour
{
    public GameObject SnowMan; // Prefab del enemigo que deseas spawnear
    public GameObject enemiesLeft;
    public GameObject waveGameObject;
    public float spawnInterval = 1.0f; // Intervalo de tiempo entre cada spawn
    public int maxEnemies = 7; // N�mero m�ximo de enemigos que pueden aparecer en la zona
    public int minEnemies = 5;
    public float space = 7.0f;
    private int wave = 1;
    private int currentEnemyCount = 0; // Contador de enemigos actuales
    private int enemyCount = 0;

    public void Start()
    {
        // Inicia el proceso de spawn de enemigos
        enemyCount = Random.Range(minEnemies, maxEnemies) + wave * 2;
        enemiesLeft.GetComponent<EnemiesLeftController>().UpdateText(enemyCount);
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);

    }
    public int CheckNumberOfEnemies()
    {
        return currentEnemyCount;
    }

    public void DecreaseNumberOfEnemies()
    {
        currentEnemyCount--;
        enemiesLeft.GetComponent<EnemiesLeftController>().UpdateText(currentEnemyCount);
    }

    public void GenerateNewWave()
    {
        wave++;
        waveGameObject.GetComponent<WaveController>().UpdateText(wave);
        enemyCount = Random.Range(minEnemies, maxEnemies) + wave * 2;
        enemiesLeft.GetComponent<EnemiesLeftController>().UpdateText(currentEnemyCount);
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);
    }

    public int CheckWave()
    {
        return wave;
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount >= enemyCount)
        {
            // Ya se alcanz� el l�mite de enemigos, no se hace spawn adicional
            CancelInvoke("SpawnEnemy");
        }

        // Instancia el prefab del enemigo en una posici�n aleatoria dentro de la zona de spawn
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(SnowMan, spawnPosition, Quaternion.identity);

        currentEnemyCount++;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Obtiene una posici�n aleatoria dentro de la zona de spawn
        Vector3 zoneCenter = transform.position;
        Vector3 zoneExtents = transform.localScale * space;

        // Intenta encontrar una posici�n aleatoria sin colisiones con otros enemigos
        int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomSpawnPos = zoneCenter + new Vector3(Random.Range(-zoneExtents.x, zoneExtents.x), 3.5f, Random.Range(-zoneExtents.z, zoneExtents.z));

            Collider[] colliders = Physics.OverlapSphere(randomSpawnPos, 1f); // Ajusta el radio seg�n el tama�o de los enemigos y la zona de spawn

            if (colliders.Length == 0)
            {
                return randomSpawnPos;
            }
        }

        // Si no se encuentra una posici�n sin colisiones despu�s de ciertos intentos, se devuelve la posici�n aleatoria original
        return zoneCenter + new Vector3(Random.Range(-zoneExtents.x, zoneExtents.x), 0.0f, Random.Range(-zoneExtents.z, zoneExtents.z));
    }
}