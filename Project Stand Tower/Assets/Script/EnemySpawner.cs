using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
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
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            Transform spawnPoint = spawnPoints[randomIndex];
            //Quaternion.identity means that the new object same rotation as old one
            GameObject enemy = Instantiate(enemyPrefab[randomEnemy], spawnPoint.position, Quaternion.identity);
            //enemy.GetComponent<EnemyController>().SpawnPoint = spawnPoint;

            nextSpawn = Time.time + spawnRate;

        }
    }
}
