using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
<<<<<<< Updated upstream
    
=======
    public float spawnDelay = 1.0f;
    public Transform[] spawnPoints;
>>>>>>> Stashed changes
    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[waypointIndex];
<<<<<<< Updated upstream
=======

        //This is method that can method in regular interval contain method to be called, and delay of invocation
        InvokeRepeating("InvokeSpawnEnemy", spawnDelay, spawnDelay);
>>>>>>> Stashed changes
    }

    void Update()
    {
        // Move towards the current waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // If the enemy has reached the current waypoint, get the next one
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            // If the enemy has reached the last waypoint, destroy it
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
<<<<<<< Updated upstream
=======

    void InvokeSpawnEnemy()
    {
        SpawnPoints anotherSP = GameObject.Find("SpawnerPos").GetComponent<SpawnPoints>();
        anotherSP.SpawnEnemy();
    }
>>>>>>> Stashed changes
}