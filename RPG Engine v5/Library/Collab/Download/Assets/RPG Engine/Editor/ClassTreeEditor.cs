using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ClassTree))]
public class ClassTreeEditor : Editor
{
    ClassTree tree;

    int yBuffer = 200;
    int xBuffer = 15;

    int realScreenY()
    {
        return Screen.height - yBuffer;
    }
    int realScreenX()
    {
        return Screen.width - xBuffer;
    }

    public override void OnInspectorGUI()
    {
        tree = (ClassTree)target;

        EditorGUILayout.BeginHorizontal(GUI.skin.button);
        GUILayout.FlexibleSpace();
        GUILayout.Label("Class Tree");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        //GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));//Centering
        //GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal(GUI.skin.box, GUILayout.Width(realScreenX()), GUILayout.Height(realScreenY()));
        //Tier1
        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(realScreenX() / 3), GUILayout.Height(realScreenY()));
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUIUtility.labelWidth = 50;
        tree.root.characterClass = EditorGUILayout.ObjectField("Base", tree.root.characterClass, typeof(CharacterClass), false, GUILayout.MaxWidth(realScreenX() / 3)) as CharacterClass;
        EditorGUIUtility.labelWidth = 0;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();

        //Tier2
        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(realScreenX() / 3), GUILayout.Height(realScreenY()));
        int tierTwos = tree.root.branches.Count;
        int count = 0;
        foreach(ClassTreeTierTwo t2 in tree.root.branches)
        {
            count++;
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal(GUILayout.Height(realScreenY()/tierTwos), GUILayout.Width(realScreenX()/3));
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            EditorGUIUtility.labelWidth = 50;
            t2.characterClass = EditorGUILayout.ObjectField("T2-" + count, t2.characterClass, typeof(CharacterClass), false, GUILayout.MaxWidth(realScreenX() / 3)) as CharacterClass;
            EditorGUIUtility.labelWidth = 0;
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndVertical();

        //Tier3
        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(realScreenX() / 3), GUILayout.Height(realScreenY()));
        int tierThrees = 2 * tierTwos;
        count = 1;
        foreach(ClassTreeTierTwo t2 in tree.root.branches)
        {
            foreach(ClassTreeTierThree t3 in t2.branches)
            {             
                GUILayout.FlexibleSpace();
                GUILayout.BeginHorizontal(GUILayout.Height(realScreenY() / tierThrees), GUILayout.Width(realScreenX() / 3));
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                GUILayout.FlexibleSpace();
                EditorGUIUtility.labelWidth = 50;
                t3.characterClass = EditorGUILayout.ObjectField("T3-" + count, t3.characterClass, typeof(CharacterClass), false, GUILayout.MaxWidth(realScreenX() / 3)) as CharacterClass;
                EditorGUIUtility.labelWidth = 0;
                GUILayout.FlexibleSpace();
                GUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.FlexibleSpace();
                count++;
            }
            count = 1;
        }

        GUILayout.EndVertical();
        GUILayout.Space(realScreenX() / 3);
        
        GUILayout.EndHorizontal();
        //GUILayout.FlexibleSpace();
        //GUILayout.EndHorizontal();
    }
}
