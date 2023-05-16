using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnZone : MonoBehaviour
{
    public GameObject SnowMan; // Prefab del enemigo que deseas spawnear
    public GameObject enemiesLeft;
    public GameObject Diana;
    public GameObject Boss; 
    public GameObject waveGameObject;
    public float spawnInterval = 1.0f; // Intervalo de tiempo entre cada spawn
    public int maxEnemies = 7; // Número máximo de enemigos que pueden aparecer en la zona
    public int minEnemies = 5;
    public float space = 7.0f;
    private int wave = 1;
    private int currentEnemyCount = 0; // Contador de enemigos actuales
    private int enemyCount = 0;
    private int SnowManCount = 0; 

    public void Start()
    {
        // Inicia el proceso de spawn de enemigos
        enemyCount = Random.Range(minEnemies, maxEnemies) + wave * 2;
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);

    }
    public int CheckNumberOfEnemies()
    {
        return currentEnemyCount;
    }

    public void DecreaseNumberOfEnemies()
    {
        currentEnemyCount--;
        enemiesLeft.GetComponent<EnemiesLeftController>().UpdateText();
    }

    public void GenerateNewWave()
    {
        wave++;
        waveGameObject.GetComponent<WaveController>().UpdateText();
        enemyCount = Random.Range(minEnemies, maxEnemies) + wave * 2;
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
            // Ya se alcanzó el límite de enemigos, no se hace spawn adicional
            enemiesLeft.GetComponent<EnemiesLeftController>().UpdateText();
            CancelInvoke("SpawnEnemy");
            SnowManCount = 0;
        }

        // Instancia el prefab del enemigo en una posición aleatoria dentro de la zona de spawn
        Vector3 spawnPosition = GetRandomSpawnPosition();
        
        switch (wave)
        {
            case 1:
                
                Instantiate(Diana, spawnPosition, Quaternion.identity);
                currentEnemyCount++;

                break;

            case 2:
                if (SnowManCount == 0)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    SnowManCount++;
                    currentEnemyCount++;
                }
                else
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 3:
                if (SnowManCount < 2)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                    SnowManCount++;
                }
                else
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 4:
                if (SnowManCount < 4)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                    SnowManCount++;
                }
                else
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            default:

                Instantiate(Boss, spawnPosition, Quaternion.identity);
                currentEnemyCount++;

                break;
        }


        
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Obtiene una posición aleatoria dentro de la zona de spawn
        Vector3 zoneCenter = transform.position;
        Vector3 zoneExtents = transform.localScale * space;

        // Intenta encontrar una posición aleatoria sin colisiones con otros enemigos
        int maxAttempts = 15;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomSpawnPos = zoneCenter + new Vector3(Random.Range(-zoneExtents.x, zoneExtents.x), 2f, Random.Range(-zoneExtents.z, zoneExtents.z));

            Collider[] colliders = Physics.OverlapSphere(randomSpawnPos, 1.5f); // Ajusta el radio según el tamaño de los enemigos y la zona de spawn

            if (colliders.Length == 0)
            {
                return randomSpawnPos;
            }
        }

        // Si no se encuentra una posición sin colisiones después de ciertos intentos, se devuelve la posición aleatoria original
        return zoneCenter + new Vector3(Random.Range(-zoneExtents.x, zoneExtents.x), 0.0f, Random.Range(-zoneExtents.z, zoneExtents.z));
    }
}