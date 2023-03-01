using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    public Transform[] spawnPoints;

    private void Update()
    {
        SpawnEnemy();
    }
    void SpawnEnemy() 
    {
    
    // Select a random spawn point from the array
    int randomIndex = Random.Range(0, spawnPoints.Length);
    Transform spawnPoint = spawnPoints[randomIndex];
    Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
