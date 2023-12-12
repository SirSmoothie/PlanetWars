
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WorldGenerator2))]
public class WorldGenerator2Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Level"))
        {
            (target as WorldGenerator2)?.GenerateLevel();
        }
    }
}
