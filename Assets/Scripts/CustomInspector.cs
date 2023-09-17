using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenerateJengaTower))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GenerateJengaTower generator = (GenerateJengaTower)target;
        if (GUILayout.Button("Generate Tower"))
            generator.GenerateTower();

        if (GUILayout.Button("Delete Tower"))
            generator.DeleteCurrentTower();
    }
}
