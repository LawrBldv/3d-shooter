using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private GameObject botPrefab; // Prefab for the bot
    [SerializeField] private Vector3 spawnAreaMin; // Minimum bounds of the spawn area
    [SerializeField] private Vector3 spawnAreaMax; // Maximum bounds of the spawn area
    [SerializeField] private int maxBots = 5; // Max number of bots in the scene
    [SerializeField] private float spawnInterval = 5f; // Time between spawns

    private float _timeSinceLastSpawn = 0f;

    private void Update()
    {
        // Check if the number of bots in the scene is below the max
        if (GameObject.FindGameObjectsWithTag("Bot").Length < maxBots)
        {
            _timeSinceLastSpawn += Time.deltaTime;

            if (_timeSinceLastSpawn >= spawnInterval)
            {
                SpawnBot();
                _timeSinceLastSpawn = 0f;
            }
        }
    }

    private void SpawnBot()
    {
        // Generate a random spawn position
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);

        Vector3 spawnPosition = new Vector3(x, y, z);

        // Instantiate the bot
        Instantiate(botPrefab, spawnPosition, Quaternion.identity);
    }
}
