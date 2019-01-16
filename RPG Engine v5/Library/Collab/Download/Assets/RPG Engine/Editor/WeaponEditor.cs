using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    Weapon weapon;
    public override void OnInspectorGUI()
    {
        weapon = (Weapon)target;

        EditorGUILayout.BeginHorizontal(GUI.skin.button);
        GUILayout.FlexibleSpace();
        GUILayout.Label("Weapon");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.BeginVertical(GUI.skin.box);

        EditorGUIUtility.labelWidth = 104;
        weapon.itemName = EditorGUILayout.TextField("Name", weapon.itemName);
        EditorGUIUtility.labelWidth = 0;
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Description", GUILayout.MaxWidth(100));
        weapon.description = EditorGUILayout.TextArea(weapon.description, GUILayout.Height(60));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        EditorGUIUtility.labelWidth = 50;
        weapon.sprite = (Sprite)EditorGUILayout.ObjectField("Sprite", weapon.sprite, typeof(Sprite), false);
        EditorGUIUtility.labelWidth = 0;
        GUILayout.EndHorizontal();

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUIUtility.labelWidth = 100;
        weapon.weaponType = (WeaponTypes)EditorGUILayout.EnumPopup("Weapon Type", weapon.weaponType, GUILayout.MaxWidth(175));
        weapon.elementAffinity = (Elements)EditorGUILayout.EnumPopup("Element Affinity", weapon.elementAffinity, GUILayout.MaxWidth(175));
        EditorGUIUtility.labelWidth = 0;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUIUtility.labelWidth = 100;
        weapon.rarity = (Rarities)EditorGUILayout.EnumPopup("Rarity", weapon.rarity, GUILayout.MaxWidth(175));
        weapon.value = EditorGUILayout.IntField("Value", weapon.value, GUILayout.MaxWidth(175));
        EditorGUIUtility.labelWidth = 0;
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        GUILayout.BeginVertical(GUI.skin.box);

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Stat Modifiers");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        foreach (CharacterStat stat in weapon.statMods)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField(stat.GetStatType().ToString(), GUILayout.MaxWidth(75));
            stat.SetValue(EditorGUILayout.IntField(stat.GetValue(), GUILayout.MaxWidth(200)));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
}
