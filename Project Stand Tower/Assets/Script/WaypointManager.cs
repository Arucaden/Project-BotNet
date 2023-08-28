using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance;
    public Transform[] waypoints;
    void Start()
    {
        Instance = this;
    }
}
