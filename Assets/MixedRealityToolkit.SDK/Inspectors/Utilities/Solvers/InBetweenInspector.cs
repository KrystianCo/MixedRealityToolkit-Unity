﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEditor;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Utilities.Editor.Solvers
{
    [CustomEditor(typeof(InBetween))]
    public class InBetweenEditor : SolverInspector
    {
        private SerializedProperty secondTrackedTargetTypeProperty;
        private SerializedProperty secondTransformOverrideProperty;
        private SerializedProperty partwayOffsetProperty;

        private InBetween solverInBetween;

        protected override void OnEnable()
        {
            base.OnEnable();

            secondTrackedTargetTypeProperty = serializedObject.FindProperty("secondTrackedObjectType");
            secondTransformOverrideProperty = serializedObject.FindProperty("secondTransformOverride");
            partwayOffsetProperty = serializedObject.FindProperty("partwayOffset");

            solverInBetween = target as InBetween;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            bool objectChanged = false;

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(secondTrackedTargetTypeProperty, new GUIContent("Second Tracked Target Type"));

            if (secondTrackedTargetTypeProperty.enumValueIndex == (int)TrackedObjectType.CustomOverride)
            {
                EditorGUILayout.PropertyField(secondTransformOverrideProperty);
            }

            objectChanged = EditorGUI.EndChangeCheck();

            EditorGUILayout.PropertyField(partwayOffsetProperty);

            serializedObject.ApplyModifiedProperties();

            if (Application.isPlaying && objectChanged)
            {
                //solverInBetween.AttachSecondTransformToNewTrackedObject();
            }
        }
    }
}
