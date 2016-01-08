using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlacementManager : MonoBehaviour
{
    public static float gridSize = 0.5f;
    private static List<Vector2> occupied;

    public GameObject[] towers;

    private Vector3 pos;
    private GameObject toMove;
    private bool shouldMove;

    void Start()
    {
    }

    void Update()
    {
        if(shouldMove)
        {
            MoveObjectToMouse(toMove);
            if(Input.GetKeyDown(KeyCode.Mouse0) && !Occupied(toMove.transform.position))
            {
                shouldMove = false;
                toMove.GetComponent<Occupy>().Take();
            }
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                shouldMove = false;
                toMove.GetComponent<Occupy>().setOnDestroy = false; //prevent removing other occupied slots when cancling tower build
                Destroy(toMove);
            }
        }
        //print(PlacementManager.occupied.Count + " Last item: " + occupied[occupied.Count-1]);
    }

    static PlacementManager()
    {
        occupied = new List<Vector2>();
    }

    public static void OccupyPosition(Vector2 pos)
    {
        occupied.Add(pos);
    }

    public static void ReleasePosition(Vector2 pos)
    {
        occupied.Remove(pos);
    }

    public static bool Occupied(Vector2 pos)
    {
        return occupied.Contains(pos);
    }

    public void BuildTower(int tower)
    {
        GameObject tw = Instantiate(towers[tower], Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
        tw.GetComponent<Occupy>().setOnStart = false; //Don't set the pos instantly
        StartMoving(tw);
    }

    public void StartMoving(GameObject g)
    {
        shouldMove = true;
        toMove = g;
    }

    public void StopMoving()
    {
        shouldMove = false;
    }

    private void MoveObjectToMouse(GameObject obj)
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos.x = (Mathf.Round(pos.x / gridSize) * gridSize);
        pos.y = (Mathf.Round(pos.y / gridSize) * gridSize);
        obj.transform.position = pos;
    }

}
