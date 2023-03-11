using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Transform target;
    [SerializeField] private float speed = 10f;
    public Transform SpawnPoint;
    private Waypoint currentWaypoint;



    // Start is called before the first frame update
    void Start()
    {
        //Get the waypoint from waypoint script
        target = SpawnPoint.GetComponent<Waypoint>().NextDestination;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
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
    }

    void GetNextWaypoint()
    {
        target = target.GetComponent<Waypoint>().NextDestination;
        if (target.GetComponent<Waypoint>().IsWaypointEnd)
        {
            Destroy(gameObject);
        }
    }
}
