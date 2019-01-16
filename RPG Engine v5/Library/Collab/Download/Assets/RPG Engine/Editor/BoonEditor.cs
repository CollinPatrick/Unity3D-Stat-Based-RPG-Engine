using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Boon))]
public class BoonEditor : Editor
{
    private int maxPoints = 50;
    private int usedPoints()
    {
        int temp = 0;
        foreach (BaseStat stat in boon.GrowthRates)
        {
            temp += stat.GetGrowthRate();
        }
        return temp;
    }

    Boon boon;

    public override void OnInspectorGUI()
    {
        boon = (Boon)target;

        EditorGUILayout.BeginHorizontal(GUI.skin.button);
        GUILayout.FlexibleSpace();
        GUILayout.Label("Boon");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.BeginVertical(GUI.skin.box);
        EditorGUIUtility.labelWidth = 104;
        boon.boonName = EditorGUILayout.TextField("Name", boon.boonName);
        EditorGUIUtility.labelWidth = 0;
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Description", GUILayout.MaxWidth(100));
        boon.description = EditorGUILayout.TextArea(boon.description, GUILayout.Height(60));
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
        GUILayout.Label("Points Remaining: " + (maxPoints - usedPoints()).ToString() + "/" + maxPoints);
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        foreach (BaseStat stat in boon.GrowthRates)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField(stat.GetStatType().ToString(), GUILayout.MaxWidth(75));
            stat.SetGrowthRate(EditorGUILayout.IntSlider(stat.GetGrowthRate(), 0, stat.GetGrowthRate() + (maxPoints - usedPoints()), GUILayout.MaxWidth(200)));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
}
