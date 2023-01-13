using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(PostProcessingStack))]
public class PostProcessingStackEditor : Editor
{
    SerializedProperty _effectList;

    void OnEnable() {
        _effectList = serializedObject.FindProperty("effects");
    }

    public override void OnInspectorGUI() {
        serializedObject.UpdateIfRequiredOrScript();

        //Draw array drawer label with array drawer to the side of it
        EditorGUILayout.BeginHorizontal();
        float labelWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth = 10;
        EditorGUILayout.LabelField("Effects", EditorStyles.boldLabel);
        EditorGUIUtility.labelWidth = labelWidth;
        EditorGUILayout.PropertyField(_effectList, GUIContent.none);
        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}
