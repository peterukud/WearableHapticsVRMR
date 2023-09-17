using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BlockPuzzleController))]
public class CustomInspectorResetPopulation : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BlockPuzzleController controller = (BlockPuzzleController)target;
        if (GUILayout.Button("Populate From Children Of 0th Element"))
            controller.PopulateFromChildrenOfZerothElement();
    }
}