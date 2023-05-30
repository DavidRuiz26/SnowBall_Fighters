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
    public GameObject vida;
    public GameObject grande;
    public GameObject piedra; 
    public float spawnInterval = 1.0f; // Intervalo de tiempo entre cada spawn
    public int maxEnemies = 7; // N�mero m�ximo de enemigos que pueden aparecer en la zona
    public int minEnemies = 5;
    public float space = 7.0f;
    private int wave = 1;
    private float prob_target = 0f;
    private float prob_Snow = 0f;
    private float prob_PowerUp = 0.05f; 
    private int currentEnemyCount = 0; // Contador de enemigos actuales
    private int enemyCount = 0;
    private int SnowManCount = 0;
    public bool isActivated = false;

    public void Activate()
    {
        isActivated = true;

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
        if (wave == 5 || wave ==10)
        {
            enemyCount = 1;
        }
        else
        {
            enemyCount = Random.Range(minEnemies, maxEnemies) + wave * 2;
        }
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);
    }

    public int CheckWave()
    {
        return wave;
    }

    public void SpawnEnemy()
    {
        if (!isActivated || currentEnemyCount >= enemyCount)
        {
            // Ya se alcanz� el l�mite de enemigos, no se hace spawn adicional
            enemiesLeft.GetComponent<EnemiesLeftController>().UpdateText();
            CancelInvoke("SpawnEnemy");
            SnowManCount = 0;
        }

        // Instancia el prefab del enemigo en una posici�n aleatoria dentro de la zona de spawn
        Vector3 spawnPosition = GetRandomSpawnPosition();
        if (Random.Range(0f, 1f) < prob_PowerUp)
        {
            switch (Random.Range(0, 2))
            {
                case 1:
                    Instantiate(vida, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(grande, spawnPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(piedra, spawnPosition, Quaternion.identity);
                    break;
                default:
                    Debug.Log("no hay penwino");
                    return;
            }
        }

        switch (wave)
        {
            case 1:
                prob_target = 0.8f;
                prob_Snow = 0.2f;
                if (Random.Range(0f,1f) < prob_target)
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                else
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 2:
                prob_target = 0.3f;
                prob_Snow = 0.7f;
                if (Random.Range(0f, 1f) < prob_target)
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                else if (Random.Range(0f, 1f) < prob_Snow)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 3:
                prob_target = 0.5f;
                prob_Snow = 0.5f;
                if (Random.Range(0f, 1f) < prob_target)
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                else if (Random.Range(0f, 1f) < prob_Snow)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 4:
                prob_target = 0.3f;
                prob_Snow = 0.7f;
                if (Random.Range(0f, 1f) < prob_target)
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                else if (Random.Range(0f, 1f) < prob_Snow)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 5: 
                Instantiate(Boss, spawnPosition, Quaternion.identity);
                currentEnemyCount++;
                break;

            case 6:
                prob_target = 0.3f;
                prob_Snow = 0.7f;
                if (Random.Range(0f, 1f) < prob_target)
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                else if (Random.Range(0f, 1f) < prob_Snow)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 7:
                prob_target = 0.2f;
                prob_Snow = 0.8f;
                if (Random.Range(0f, 1f) < prob_target)
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                else if (Random.Range(0f, 1f) < prob_Snow)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 8:
                prob_target = 0.2f;
                prob_Snow = 0.8f;
                if (Random.Range(0f, 1f) < prob_target)
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                else if (Random.Range(0f, 1f) < prob_Snow)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 9: 
                prob_target = 0.1f;
                prob_Snow = 0.9f;
                if (Random.Range(0f, 1f) < prob_target)
                {
                    Instantiate(Diana, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                else if (Random.Range(0f, 1f) < prob_Snow)
                {
                    Instantiate(SnowMan, spawnPosition, Quaternion.identity);
                    currentEnemyCount++;
                }
                break;

            case 10:

                Instantiate(Boss, spawnPosition, Quaternion.identity);
                currentEnemyCount++;
                break;

            default:
                CancelInvoke("SpawnEnemy");
                return; 
        }
    }

    public Vector3 GetRandomSpawnPosition()
    {
        // Obtiene una posici�n aleatoria dentro de la zona de spawn
        Vector3 zoneCenter = transform.position;
        Vector3 zoneExtents = transform.localScale * space;

        // Intenta encontrar una posici�n aleatoria sin colisiones con otros enemigos
        int maxAttempts = 15;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomSpawnPos = zoneCenter + new Vector3(Random.Range(-zoneExtents.x, zoneExtents.x), 2f, Random.Range(-zoneExtents.z, zoneExtents.z));

            Collider[] colliders = Physics.OverlapSphere(randomSpawnPos, 1.5f); // Ajusta el radio seg�n el tama�o de los enemigos y la zona de spawn

            if (colliders.Length == 0)
            {
                return randomSpawnPos;
            }
        }

        // Si no se encuentra una posici�n sin colisiones despu�s de ciertos intentos, se devuelve la posici�n aleatoria original
        return zoneCenter + new Vector3(Random.Range(-zoneExtents.x, zoneExtents.x), 0.0f, Random.Range(-zoneExtents.z, zoneExtents.z));
    }
}
