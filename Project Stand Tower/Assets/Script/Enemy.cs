using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    //public GameObject enemyPrefab;
    public float spawnDelay = 1.0f;
    public Transform[] spawnPoints;
    
    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
       
        //Get the waypoint from waypoint script
        target = Waypoints.waypoints[waypointIndex];

        //This is method that can method in regular interval contain method to be called, and delay of invocation
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }

    void Update()
    {
        // Move towards the current waypoint
        Vector2 dir = target.position - transform.position;
        //Move the object using specific direction
        //using normalize means that the speed when the object translate are constant
        //Time.deltaTime used for equate speed of the object in different FPS
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        // If the enemy has reached the current waypoint, get the next one
        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            // If the enemy has reached the last waypoint, destroy the game object
            Destroy(gameObject);
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void SpawnEnemy()
    {
        SpawnPoints invokeSP = GameObject.Find("SpawnerPos").GetComponent<SpawnPoints>();
        invokeSP.SpawnEnemy();
    }
}