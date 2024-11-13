using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float minRandomRangeX = 70.0f; //70 - 88
    private float maxRandomRangeX = 88.0f;
    private float minRandomRangeZ = 60.0f;
    private float maxRandomRangeZ = 85.0f;
    public int enemyCount;
    public int waveNumber = 1;

    private float spawnTimer = 0.0f;  // Timer for controlling spawn rate
    private float spawnInterval = 5.0f;  // Time interval for spawning (5 seconds)

    void Start()
    {
        SpawnEnemyWave(waveNumber); // Initial spawn on start
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // Initial powerup spawn
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // Get current number of enemies

        // Timer counting down
        spawnTimer += Time.deltaTime; // Increase timer by time passed since last frame

        // If timer reaches the interval, spawn enemies and reset timer
        if (spawnTimer >= spawnInterval)
        {
            // Spawn enemies for the current wave
            SpawnEnemyWave(waveNumber);
            
            // Spawn a powerup
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

            // Reset the timer
            spawnTimer = 0.0f;
        }

        // Check if all enemies are gone, and if so, start next wave
        if (enemyCount == 0)
        {
            waveNumber++;
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(minRandomRangeX, maxRandomRangeX);
        float spawnPosZ = Random.Range(minRandomRangeZ, maxRandomRangeZ); // Random X, Z

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ); // Create position for enemies
        return randomPos;
    }
}
