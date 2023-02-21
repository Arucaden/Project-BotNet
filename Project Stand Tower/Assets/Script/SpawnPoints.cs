using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public Transform[] spawnPoints;

    void SpawnEnemy() 
    {
    // Select a random spawn point from the array
    int randomIndex = Random.Range(0, spawnPoints.Length);
    Transform spawnPoint = spawnPoints[randomIndex];
    }
}
