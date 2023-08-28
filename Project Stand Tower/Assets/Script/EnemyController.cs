using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;
    public float movSpeed;

    void Start()
    {
        target = WaypointManager.Instance.waypoints[waypointIndex];
    }

    void Update()
    {
        if (target != null)
        {
            // Move towards the current waypoint
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * movSpeed * Time.deltaTime);

            // If the enemy has reached the current waypoint, get the next one
            if (Vector2.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex < WaypointManager.Instance.waypoints.Length)
        {
            target = WaypointManager.Instance.waypoints[waypointIndex];
            waypointIndex++;
            Debug.Log(waypointIndex);
        }
        else 
        {
            // If the enemy has reached the last waypoint, destroy the game object
            Destroy(gameObject);
        }
    }

    public void GetTransform(Transform newTarget)
    {
        target = newTarget;
    }
}
