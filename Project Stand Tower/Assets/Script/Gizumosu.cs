using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizumosu : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // Draw a small sphere at each waypoint position
        for (int i = 0; i < Waypoints.waypoints.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(Waypoints.waypoints[i].position, 0.25f);
            // Draw a line between each waypoint and the next one
            if (i < Waypoints.waypoints.Length - 1)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawLine(Waypoints.waypoints[i].position, Waypoints.waypoints[i + 1].position);
            }
            
        }
    }
}