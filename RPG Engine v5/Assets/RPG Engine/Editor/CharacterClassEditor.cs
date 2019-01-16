using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CharacterClass))]
public class CharacterClassEditor : Editor
{
    private int maxPoints = 200;
    private int usedPoints()
    {
        int temp = 0;
        foreach(BaseStat stat in characterClass.GrowthRates)
        {
            temp += stat.GetGrowthRate();
        }
        return temp;
    }

    private int tierBar()
    {
        return characterClass.tier;
    }

    private string[] tierBarStrings = { "Tier 1", "Tier 2", "Tier 3" };

    private int maxStatPoints()
    {
        if(tierBar() == 0)
        {
            return 20;
        }
        if (tierBar() == 1)
        {
            return 40;
        }
        if (tierBar() == 2)
        {
            return 60;
        }
        return 20;
    }
    private int usedStatPoints()
    {
        int i = 0;
        foreach(BaseStat stat in characterClass.stats)
        {
            i += stat.GetValue();
        }
        return i;
    }

    CharacterClass characterClass;

    public override void OnInspectorGUI()
    {
        characterClass = (CharacterClass)target;

        EditorGUILayout.BeginHorizontal(GUI.skin.button);
        GUILayout.FlexibleSpace();
        GUILayout.Label("Class");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.BeginVertical(GUI.skin.box);
        EditorGUIUtility.labelWidth = 104;
        characterClass.className = EditorGUILayout.TextField("Name", characterClass.className);
        EditorGUIUtility.labelWidth = 0;
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Description", GUILayout.MaxWidth(100));
        characterClass.description = EditorGUILayout.TextArea(characterClass.description, GUILayout.Height(60));
        GUILayout.EndHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUIUtility.labelWidth = 100;
        characterClass.weaponType = (WeaponTypes)EditorGUILayout.EnumPopup("Weapon Type",characterClass.weaponType, GUILayout.MaxWidth(175));
        characterClass.elementAffinity = (Elements)EditorGUILayout.EnumPopup("Element Affinity", characterClass.elementAffinity, GUILayout.MaxWidth(175));
        EditorGUIUtility.labelWidth = 0;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();


        GUILayout.BeginVertical(GUI.skin.box);

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Base Stats");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        characterClass.tier = GUILayout.Toolbar(characterClass.tier, tierBarStrings, GUILayout.MaxWidth(275));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Points Remaining: " + (maxStatPoints() - usedStatPoints()).ToString() + "/" + maxStatPoints());
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        foreach (CharacterStat stat in characterClass.stats)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField(stat.GetStatType().ToString(), GUILayout.MaxWidth(75));
            stat.SetValue(EditorGUILayout.IntSlider(stat.GetValue(), 0, stat.GetValue() + (maxStatPoints() - usedStatPoints()), GUILayout.MaxWidth(200)));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
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

        foreach (BaseStat stat in characterClass.GrowthRates)
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
