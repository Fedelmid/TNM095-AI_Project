﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehaviour))]
public class CompositeBehaviorEditor : Editor // more convenient editor for flock behaviour
{
    private FlockBehaviour adding; // a new behaviour

    private FlockBehaviour[] Remove(int index, FlockBehaviour[] old)
    {
        // Remove this behaviour
        var current = new FlockBehaviour[old.Length - 1];
        for (int y = 0, x = 0; y < old.Length; y++)
        {
            if (y != index)
            {
                current[x] = old[y];
                x++;
            }
        }
        return current;
    }

    public override void OnInspectorGUI()
    {
        // Setup
        var current = (CompositeBehaviour)target;
        EditorGUILayout.BeginHorizontal();

        // Draw
        if (current.behaviours == null || current.behaviours.Length == 0)
        {
            EditorGUILayout.HelpBox("No behaviours attached.", MessageType.Warning);
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.LabelField("Behaviours");
            EditorGUILayout.LabelField("Weights");
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < current.behaviours.Length; i++)
            {
                // Draw index      
                EditorGUILayout.BeginHorizontal();

                if (GUILayout.Button("Remove") || current.behaviours[i] == null)
                {
                    // Remove this behaviour
                    current.behaviours = Remove(i, current.behaviours);
                    break;
                }

                current.behaviours[i] = (FlockBehaviour)EditorGUILayout.ObjectField(current.behaviours[i], typeof(FlockBehaviour), false);
                EditorGUILayout.Space(30);
                current.weights[i] = EditorGUILayout.Slider(current.weights[i], 0, 1);

                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUILayout.EndHorizontal();


        // possibility to add new behaviour
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Add behaviour...");
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        adding = (FlockBehaviour)EditorGUILayout.ObjectField(adding, typeof(FlockBehaviour), false);

        if (adding != null && current.behaviours != null)
        {
            // add this item to the array
            var oldBehaviours = current.behaviours;
            current.behaviours = new FlockBehaviour[oldBehaviours.Length + 1];
            var oldWeights = current.weights;
            current.weights = new float[oldWeights.Length + 1];

            for (int i = 0; i < oldBehaviours.Length; i++)
            {
                current.behaviours[i] = oldBehaviours[i];
                current.weights[i] = oldWeights[i];
            }

            current.behaviours[oldBehaviours.Length] = adding;
            current.weights[oldWeights.Length] = 1;

            adding = null;
        }
    }
}
