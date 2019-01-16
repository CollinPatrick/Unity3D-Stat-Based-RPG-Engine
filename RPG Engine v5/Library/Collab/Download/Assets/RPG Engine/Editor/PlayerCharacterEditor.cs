using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerCharacter))]
public class PlayerCharacterEditor : Editor
{
    PlayerCharacter character;

    bool showStats = true;
    bool showStatusEffects = true;
    bool showInventory = true;

    void OnEnable()
    {
        //target = serializedObject.FindProperty("PlayerCharacter");
    }

    public override void OnInspectorGUI()
    {
        character = (PlayerCharacter)target;
        /*serializedObject.Update();
        EditorGUILayout.PropertyField(target);
        serializedObject.ApplyModifiedProperties();
        */
        EditorGUILayout.BeginHorizontal(GUI.skin.button);
        GUILayout.FlexibleSpace();
        GUILayout.Label("PLAYER CHARACTER SHEET");
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUI.BeginDisabledGroup(Application.isPlaying);
        EditorGUIUtility.labelWidth = 50;
        character.characterName = EditorGUILayout.TextField("Name", character.characterName, GUILayout.MaxWidth(150));
        EditorGUIUtility.labelWidth = 0;
        EditorGUI.EndDisabledGroup();
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);
        GUIStyle center = new GUIStyle();
        center.alignment = TextAnchor.MiddleCenter;
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField("Lvl. " + character.level, center, GUILayout.MaxWidth(100));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField("Exp: " + character.GetExp() + "/" + character.GetNeededExp(), center, GUILayout.MaxWidth(100));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField("Gold: " + character.gold, center, GUILayout.MaxWidth(100));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10);

        EditorGUI.BeginDisabledGroup(Application.isPlaying);
        EditorGUIUtility.labelWidth = 70;
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        character.classTree = EditorGUILayout.ObjectField("Class Tree", character.classTree, typeof(ClassTree), false, GUILayout.MaxWidth(200)) as ClassTree;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUIUtility.labelWidth = 55;
        character.characterClass  = EditorGUILayout.ObjectField("Class",character.characterClass, typeof(CharacterClass), false, GUILayout.MaxWidth(150)) as CharacterClass;
        GUILayout.Space(25);
        character.bloodline = EditorGUILayout.ObjectField("Bloodline", character.bloodline, typeof(Bloodline), false, GUILayout.MaxWidth(150)) as Bloodline;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        character.boon = EditorGUILayout.ObjectField("Boon", character.boon, typeof(Boon), false, GUILayout.MaxWidth(150)) as Boon;
        GUILayout.Space(25);
        character.bane = EditorGUILayout.ObjectField("Bane", character.bane, typeof(Bane), false, GUILayout.MaxWidth(150)) as Bane;
        EditorGUIUtility.labelWidth = 0;
        EditorGUILayout.EndHorizontal();
        EditorGUI.EndDisabledGroup();

        GUILayout.EndVertical();

        showInventory = EditorGUILayout.Foldout(showInventory, "Inventory");
        if (showInventory)
        {  
                GUILayout.BeginVertical(GUI.skin.box);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Inventory");
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Space(50);
                EditorGUILayout.LabelField("Name", GUILayout.MaxWidth(100));
                EditorGUILayout.LabelField("Rarity", GUILayout.MaxWidth(75));
                EditorGUILayout.LabelField("Value", GUILayout.MaxWidth(75));
                GUILayout.EndHorizontal();

            if (Application.isPlaying)
            {
                bool darken = false;
                Color old = GUI.color;

                foreach (Item item in character.inventory)
                {
                    GUIStyle style = new GUIStyle();
                    style.normal.background = item.sprite.texture;

                    if (darken)
                    {
                        GUI.color = new Color(211, 211, 211, 255);
                    }
                    darken = !darken;
                    GUILayout.BeginHorizontal(GUI.skin.box);
                    GUI.color = old;
                    EditorGUILayout.LabelField(GUIContent.none, style, GUILayout.Width(30), GUILayout.Height(30));

                    //GUILayout.BeginVertical();
                    //GUILayout.FlexibleSpace();
                    //GUILayout.BeginHorizontal();
                    GUILayout.Space(15);
                    EditorGUILayout.LabelField(item.itemName, GUILayout.MaxWidth(100));
                    EditorGUILayout.LabelField(item.rarity.ToString(), GUILayout.MaxWidth(75));
                    EditorGUILayout.LabelField(item.value.ToString() + "g", GUILayout.MaxWidth(75));
                    //GUILayout.EndHorizontal();
                    //GUILayout.FlexibleSpace();
                    //GUILayout.EndVertical();

                    GUILayout.EndHorizontal();
                }
                GUI.color = old;
            }
            else
            {
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.LabelField("EDITOR NOT IN PLAY MODE!", GUILayout.MaxWidth(300));
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }


        showStats = EditorGUILayout.Foldout(showStats, "Character Stats");
        if (showStats)
        {
            GUILayout.BeginVertical(GUI.skin.box);//, GUILayout.MinWidth(300));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Character Stats");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Stat", GUILayout.MaxWidth(75));
            EditorGUILayout.LabelField("Static", GUILayout.MaxWidth(75));
            EditorGUILayout.LabelField("Dynamic", GUILayout.MaxWidth(75));
            EditorGUILayout.LabelField("Growth Rate", GUILayout.MaxWidth(75));
            GUILayout.EndHorizontal();

            if (Application.isPlaying)
            {
                bool darken = false;
                Color old = GUI.color;

                foreach (Stat stat in character.GetStats())
                {
                    if (darken)
                    {
                        GUI.color = new Color(211, 211, 211, 255);
                    }
                    darken = !darken;

                    GUILayout.BeginHorizontal(GUI.skin.box);
                    GUI.color = old;
                    EditorGUILayout.LabelField(stat.statType().ToString(), GUILayout.MaxWidth(75));
                    if (stat.StaticStatMaxValue() > 0)
                    {
                        EditorGUILayout.LabelField(stat.StaticStatValue() + "/" + stat.StaticStatMaxValue(), GUILayout.MaxWidth(75));
                        EditorGUILayout.LabelField(stat.DynamicStatValue() + "/" + stat.DynamicStatMaxValue(), GUILayout.MaxWidth(75));
                    }
                    else
                    {
                        EditorGUILayout.LabelField(stat.StaticStatValue().ToString(), GUILayout.MaxWidth(75));
                        EditorGUILayout.LabelField(stat.DynamicStatValue().ToString(), GUILayout.MaxWidth(75));
                    }
                    EditorGUILayout.LabelField(stat.GetGrowthRate().ToString() + "%", GUILayout.MaxWidth(75));
                    GUILayout.EndHorizontal();
                    
                }
                GUI.color = old;
            }
            else
            {
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.LabelField("EDITOR NOT IN PLAY MODE!", GUILayout.MaxWidth(300));
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }

        showStatusEffects = EditorGUILayout.Foldout(showStatusEffects, "Status Effects");
        if (showStatusEffects)
        {
            GUILayout.BeginVertical(GUI.skin.box);//, GUILayout.MinWidth(300));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Status Effects");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Name", GUILayout.MaxWidth(150));
            EditorGUILayout.LabelField("Duration", GUILayout.MaxWidth(75));
            EditorGUILayout.LabelField("Time Left", GUILayout.MaxWidth(75));
            //EditorGUILayout.LabelField("Growth Rate", GUILayout.MaxWidth(75));
            GUILayout.EndHorizontal();

            if (Application.isPlaying)
            {
                foreach (StatModifierObject obj in character.GetStatModifiers())
                {
                    GUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(obj.modifierName, GUILayout.MaxWidth(150));
                    EditorGUILayout.LabelField(obj.modifierTotalDuration().ToString() + "s", GUILayout.MaxWidth(75));
                    EditorGUILayout.LabelField(obj.DurationTimeLeft() + "s", GUILayout.MaxWidth(75));
                    GUILayout.EndHorizontal();
                }
            }
            else
            {
                GUILayout.Space(20);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.LabelField("EDITOR NOT IN PLAY MODE!", GUILayout.MaxWidth(300));
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();
        }

        DrawDefaultInspector();
    }
}
