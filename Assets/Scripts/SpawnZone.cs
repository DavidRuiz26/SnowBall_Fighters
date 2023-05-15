using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject SnowMan; // Prefab del enemigo que deseas spawnear
    public float spawnInterval = 1.0f; // Intervalo de tiempo entre cada spawn
    public int maxEnemies = 10; // N�mero m�ximo de enemigos que pueden aparecer en la zona
    public float space = 7.0f;

    public int currentEnemyCount = 0; // Contador de enemigos actuales
    public bool isActivated = false;

    public void Activate(){
        isActivated = true;

        // Inicia el proceso de spawn de enemigos
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);
    }

    public void SpawnEnemy()
    {
        if (!isActivated || currentEnemyCount >= maxEnemies)
        {
            // Ya se alcanz� el l�mite de enemigos, no se hace spawn adicional
            return;
        }

        // Instancia el prefab del enemigo en una posici�n aleatoria dentro de la zona de spawn
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(SnowMan, spawnPosition, Quaternion.identity);

        currentEnemyCount++;
    }

    public Vector3 GetRandomSpawnPosition()
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