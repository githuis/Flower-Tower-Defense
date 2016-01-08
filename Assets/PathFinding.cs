using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour
{
    private GameObject[] waypoints;
    private int currentWaypoint, waypointNum;
    private float minDistance = 0.1f;

    private Mob mob;

    void Start()
    {
        waypoints = GetWaypoints();
        waypointNum = waypoints.Length;
        currentWaypoint = 0;

        mob = GetComponent<Mob>();

        transform.position = waypoints[currentWaypoint].transform.position;
    }

    void Update()
    {
        CheckWaypoint();
    }

    GameObject[] GetWaypoints()
    {
        return WaypointHost.GetAllWaypoints();
    }

    private bool CloseEnough(GameObject waypoint)
    {
        return (Vector2.Distance(waypoint.transform.position, transform.position) <= minDistance);
    }

    private void CheckWaypoint()
    {
        if(CloseEnough(waypoints[currentWaypoint]))
        {
           if(currentWaypoint < waypointNum - 1)
           {
               currentWaypoint++;
           }
           else
               ReachedFinish();
        }
        else
        {
            Move();
        }
    }

    private void ReachedFinish()
    {
        print("whoop");
    }
    
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, mob.GetSpeed() * Time.deltaTime);
    }
}
