using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class WaypointHost
{
    private static List<GameObject> waypoints = new List<GameObject>{};
   
    public static GameObject[] GetAllWaypoints()
    {
        waypoints.Sort((x, y) => x.name.CompareTo(y.name));
        return waypoints.ToArray();
    }

    public static void AddWaypoint(GameObject way)
    {
        waypoints.Add(way);
    }
}
