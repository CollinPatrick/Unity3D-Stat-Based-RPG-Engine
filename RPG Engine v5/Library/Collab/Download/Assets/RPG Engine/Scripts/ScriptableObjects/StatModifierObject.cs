using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Only supports one effect per stat per modifier object

[CreateAssetMenu(fileName = "New Stat Modifier", menuName = "RPG Engine/Stat Modifier")]
public class StatModifierObject : ScriptableObject
{
    public string modifierName;

    public statModifierGroup[] modifiers;

    private float time = 0f;
    private bool expired = false;

    public bool status()
    {
        return expired;
    }

    public IEnumerator Tick()
    {
        if (modifierTotalDuration() > 0)
        {
            while (time < modifierTotalDuration())
            {

                time += Time.deltaTime;
                yield return null;
            }
            expired = true;
        }
    }

    //Longest duration of all stat modifiers
    public float modifierTotalDuration()
    {
        float temp = 0f;
        foreach (statModifierGroup mod in modifiers)
        {
            if (mod.duration == 0)
            {
                return 0;
            }
            else if (mod.duration > temp)
            {
                temp = mod.duration;
            }
        }
        return temp;
    }

    public float DurationTimeLeft()
    {
        return (float)System.Math.Round(modifierTotalDuration() - time, 1);
    }
}

[System.Serializable]
public class statModifierGroup
{
    public StatTypes statType;
    public int value;
    public int maxValue;
    public float duration;
}
