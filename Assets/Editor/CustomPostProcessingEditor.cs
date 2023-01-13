using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CustomPostProcessing), true)]
public class CustomPostProcessingEditor : Editor {

    SerializedProperty _effectList;
    SerializedProperty _viewInEditor;

    private Editor _stackEditorCache;

    private void OnEnable() {
        _effectList = serializedObject.FindProperty("effectStack");
        _viewInEditor = serializedObject.FindProperty("viewInEditor");
    }

    public override void OnInspectorGUI() {
        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.PropertyField(_viewInEditor, new GUIContent("View Effects in Editor?"));

        //Show original scriptable object selection line
        EditorGUILayout.PropertyField(_effectList, new GUIContent("Effect Stack"));

        //If SO is selected, display its contents (editable) below
        if(_effectList.objectReferenceValue != null) {
            EditorGUI.indentLevel += 1;
            CreateCachedEditor(_effectList.objectReferenceValue, null, ref _stackEditorCache);
            _stackEditorCache.OnInspectorGUI();
            EditorGUI.indentLevel -= 1;
        } else {
            EditorGUILayout.HelpBox("No Post Processing stack is selected so no Post Processing will be applied to this camera", MessageType.Warning);
        }

        serializedObject.ApplyModifiedProperties();
    }

}
