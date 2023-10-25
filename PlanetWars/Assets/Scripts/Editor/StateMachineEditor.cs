using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StateBase), true)]
public class StateMachineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Change State"))
        {
            StateBase stateBase;
            stateBase = target as StateBase;
            if (stateBase != null)
            {
                stateBase.Change();
            }
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Set State"))
        {
            StateBase stateBase;
            stateBase = target as StateBase;
            if (stateBase != null)
            {
                stateBase.SetState(stateBase);
            }
        }
        GUILayout.EndHorizontal();
    }
}
