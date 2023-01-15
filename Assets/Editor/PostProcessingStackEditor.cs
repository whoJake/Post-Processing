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
        
        //Only draw the list (not the script header)
        EditorGUILayout.PropertyField(_effectList);

        serializedObject.ApplyModifiedProperties();
    }
    
}

