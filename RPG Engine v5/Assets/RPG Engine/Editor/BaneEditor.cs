using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Bane))]
public class BaneEditor : Editor
{
    private int minPoints = -50;
    private int usedPoints()
    {
        int temp = 0;
        foreach (BaseStat stat in bane.GrowthRates)
        {
            temp += stat.GetGrowthRate();
        }
        return temp;
    }

    Bane bane;
    public override void OnInspectorGUI()
    {
        bane = (Bane)target;

        EditorGUILayout.BeginHorizontal(GUI.skin.button);
        GUILayout.FlexibleSpace();
        GUILayout.Label("Bane");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.BeginVertical(GUI.skin.box);
        EditorGUIUtility.labelWidth = 104;
        bane.baneName = EditorGUILayout.TextField("Name", bane.baneName);
        EditorGUIUtility.labelWidth = 0;
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Description", GUILayout.MaxWidth(100));
        bane.description = EditorGUILayout.TextArea(bane.description, GUILayout.Height(60));
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();



        GUILayout.BeginVertical(GUI.skin.box);

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Growth Rates");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Points Remaining: " + (-1*(minPoints - usedPoints())).ToString() + "/" + minPoints * -1);
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        foreach (BaseStat stat in bane.GrowthRates)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField(stat.GetStatType().ToString(), GUILayout.MaxWidth(75));
            stat.SetGrowthRate(EditorGUILayout.IntSlider(stat.GetGrowthRate(), (minPoints - usedPoints()) + stat.GetGrowthRate(), 0, GUILayout.MaxWidth(200)));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();

        //bane.SetGrowthRates(GrowthRates);
    }
}
