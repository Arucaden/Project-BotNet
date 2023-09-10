using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public static Transform[] waypoints;
    public Transform NextDestination;

    void Awake()
    {
        waypoints = new Transform[transform.childCount]; //Count how many children of parent has

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i); //Set the children gameobject as waypoint
        }   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, NextDestination.position);
        // Draw a small sphere at each waypoint position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }

}
