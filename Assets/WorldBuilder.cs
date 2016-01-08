using UnityEngine;
using System.Collections;

public class WorldBuilder : MonoBehaviour
{
    private static float gridsize = PlacementManager.gridSize;

    public bool showGrid = false;
    public Vector2 selPos;

    void Awake()
    {

    }

    void Update()
    {

    }

    void OnDrawGizmos()
    {
        /*if(showGrid)
        {
            Vector3 pos = Camera.main.transform.position;

            for (float y = pos.y - 800.5f; y < pos.y + 800.5f; y += gridsize)
            {
                Gizmos.DrawLine(new Vector3(-1000000.0f, Mathf.Floor(y / gridsize) * gridsize, 0.0f),
                                new Vector3(1000000.0f, Mathf.Floor(y / gridsize) * gridsize, 0.0f));
            }

            for (float x = pos.x - 1200.5f; x < pos.x + 1200.5f; x += gridsize)
            {
                Gizmos.DrawLine(new Vector3(Mathf.Floor(x / gridsize) * gridsize, -1000000.0f, 0.0f),
                                new Vector3(Mathf.Floor(x / gridsize) * gridsize, 1000000.0f, 0.0f));
            }
        }*/

        Gizmos.DrawLine(new Vector3(selPos.x - gridsize / 4, selPos.y + gridsize / 4, 0f),
                        new Vector3(selPos.x + gridsize / 4, selPos.y - gridsize / 4, 0f));
        Gizmos.DrawLine(new Vector3(selPos.x + gridsize / 4, selPos.y + gridsize / 4, 0f),
                        new Vector3(selPos.x - gridsize / 4, selPos.y - gridsize / 4, 0f));
    }
}
