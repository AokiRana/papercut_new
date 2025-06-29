using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(PaperBridge),true)]
[InitializeOnLoad]
public class PaperBrigdeEditor : Editor
{

    public PaperBridge paperBrigdeTarget
    {
        get
        {
            return target as PaperBridge;
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        Handles.color = Color.green;
        PaperBridge t = paperBrigdeTarget;

        EditorGUI.BeginChangeCheck();

        Vector3 oldPositon = t.GetStartPositon();

        var fmh_38_65_638059460332000081 = Quaternion.identity; Vector3 newPostion = Handles.FreeMoveHandle(oldPositon, 0.5f, new Vector3(0.1f, 0.1f), Handles.CubeHandleCap);


        if (EditorGUI.EndChangeCheck())
        {
            t.paperBrigdeStartPoint.StartPostion = newPostion;
        }

    }


}
