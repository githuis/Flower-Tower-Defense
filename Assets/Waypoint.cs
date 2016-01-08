using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour
{
    void Awake()
    {
        WaypointHost.AddWaypoint(gameObject);
    }
}
