using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public Transform spawnPoint;
    public Text waveText;
    
    private int currentWave = 0;
    private int enemiesRemaining = 0;

    void Start()
    {
        StartCoroutine(SpawnWave(waves[currentWave]));
    }

    void Update()
    {
        if (currentWave > waves.Length)
        {
            // Game is won
            Debug.Log("You win!");
        }
        else if (enemiesRemaining <= 0)
        {
            // Spawn next wave
            StartCoroutine(SpawnWave(waves[currentWave]));
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        currentWave++;
        waveText.text = "Wave " + currentWave.ToString();

        enemiesRemaining = wave.enemyCount;

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        //enemy.GetComponent<Enemy>().OnEnemyDeath += OnEnemyDeath;
    }

    void OnEnemyDeath()
    {
        enemiesRemaining--;
    }
}