using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    void Awake()
    {
        waypoints = new Transform[transform.childCount]; //Count how many children of parent has

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i); //Set the children to waypoint
        }   

    }
}
