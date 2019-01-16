using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Bloodline))]
public class BloodlineEditor : Editor
{
    private int maxPoints = 100;
    private int usedPoints()
    {
        int temp = 0;
        foreach(BaseStat stat in bloodline.GrowthRates)
        {
            temp += stat.GetGrowthRate();
        }
        return temp;
    }

    Bloodline bloodline;

    public override void OnInspectorGUI()
    {
        bloodline = (Bloodline)target;

        EditorGUILayout.BeginHorizontal(GUI.skin.button);
        GUILayout.FlexibleSpace();
        GUILayout.Label("Bloodline");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.BeginVertical(GUI.skin.box);
        EditorGUIUtility.labelWidth = 104;
        bloodline.bloodlineName = EditorGUILayout.TextField("Name", bloodline.bloodlineName);
        EditorGUIUtility.labelWidth = 0;
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Description", GUILayout.MaxWidth(100));
        bloodline.description = EditorGUILayout.TextArea(bloodline.description, GUILayout.Height(60));
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
        GUILayout.Label("Points Remaining: " + (maxPoints-usedPoints()).ToString() + "/" + maxPoints);
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        foreach (BaseStat stat in bloodline.GrowthRates)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField(stat.GetStatType().ToString(), GUILayout.MaxWidth(75));
            stat.SetGrowthRate(EditorGUILayout.IntSlider(stat.GetGrowthRate(), 0, stat.GetGrowthRate() + (maxPoints - usedPoints()), GUILayout.MaxWidth(200)));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();

        GUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Skills");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();



        GUILayout.EndVertical(); 
    }
}
