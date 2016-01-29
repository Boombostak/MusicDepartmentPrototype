using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ReverbCalculator))]
public class ReverbCalculatorEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ReverbCalculator myScript = (ReverbCalculator)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.SetUp();
        }
    }
}
