using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    public void SpawnEnemy() 
    {
    // Select a random spawn point from the array
    int randomIndex = 0;
    Transform spawnPoint = spawnPoints[randomIndex];

     //This method clone GO or prefab using specific command, contain object that to be instantiate, position of new object
     //Quaternion.identity means that the new object same rotation as old one
     if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
