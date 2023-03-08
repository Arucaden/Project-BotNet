using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    private float nextSpawn;

    private void Update()
    {
        SpawnEnemy();
    }



    private void SpawnEnemy()
    {
        if (Time.time > nextSpawn)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];
            //This method clone G.O or prefab using specific command, contain object that to be instantiate, position of new object
            //Quaternion.identity means that the new object same rotation as old one
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyController>().SpawnPoint = spawnPoint;
            
            nextSpawn = Time.time + spawnRate;
        }
    }
}
