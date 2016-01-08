using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(WorldBuilder))]
public class WorldBuilderEditor : Editor
{
    WorldBuilder wb;
    Vector2 pos;

    public GameObject grass, dirt, selected;

    public void OnEnable()
    {
        wb = (WorldBuilder)target;
        pos = wb.selPos;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Show/Hide Grid"))
        {
            wb.showGrid = !wb.showGrid;
            SceneView.RepaintAll();
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginVertical();
        //dirt = (GameObject)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 20), "Find Dependency", obj, typeof(GameObject));
        //grass = (GameObject)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 20), "Find Dependency", obj, typeof(GameObject));
        //grass = (GameObject)EditorGUI.ObjectField(new Rect(0, 0, 100, 100), "Buildable", grass, typeof(GameObject));
        grass = (GameObject) EditorGUILayout.ObjectField("Buildable", grass, typeof(GameObject), true);
        dirt = (GameObject)EditorGUILayout.ObjectField("Path", dirt, typeof(GameObject), true);

        //grass = EditorGUI.ObjectField("Buildable Tile", grass, typeof(GameObject), false));
        GUILayout.EndHorizontal();
        GUILayout.BeginVertical(GUILayout.Height(50));
        GUILayout.Label("Tile Menu");

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Buildable Tile"))
        {
            selected = grass;
        }


        if (GUILayout.Button("Path Tile"))
        {
            selected = dirt;
        }
        GUILayout.EndHorizontal();

        GUILayout.Label("Navigation Menu");
        GUILayout.Label("Position - x: " + pos.x + "  y: " + pos.y + "  Selected: " + ((selected != null) ? selected.name : "None"));

        GUILayout.BeginHorizontal();
        GUI.color = Color.white;
        GUILayout.Button("", GUILayout.Width(50), GUILayout.Height(50));
        if (GUILayout.Button("Up", GUILayout.Width(50), GUILayout.Height(50)))
        {
            pos.y += PlacementManager.gridSize;
            SceneView.RepaintAll();
        }
        GUILayout.Button("", GUILayout.Width(50), GUILayout.Height(50));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        
        if (GUILayout.Button("Left", GUILayout.Width(50), GUILayout.Height(50)))
        {
            pos.x -= PlacementManager.gridSize;
            SceneView.RepaintAll();
        }
        GUI.color = Color.green;
        if (GUILayout.Button("Place", GUILayout.Width(50), GUILayout.Height(50)))
        {
            if(selected != null)
                Instantiate(selected, pos, Quaternion.identity);
        }
        GUI.color = Color.white;
        if (GUILayout.Button("Right", GUILayout.Width(50), GUILayout.Height(50)))
        {
            pos.x += PlacementManager.gridSize;
            SceneView.RepaintAll();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button("", GUILayout.Width(50), GUILayout.Height(50));
        if (GUILayout.Button("Down", GUILayout.Width(50), GUILayout.Height(50)))
        {
            pos.y -= PlacementManager.gridSize;
            SceneView.RepaintAll();
        }
        GUILayout.Button("", GUILayout.Width(50), GUILayout.Height(50));
        GUILayout.EndHorizontal();


        GUILayout.EndVertical();

        wb.selPos = pos;

    }
}
