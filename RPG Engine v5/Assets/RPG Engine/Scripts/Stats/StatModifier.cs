//** NOTES **
//Make static time pause variable to stop modifiers from running during cutscenes
using System.Collections;
using UnityEngine;

public class StatModifier
{
    private StatModifierObject obj;

    //These are modifiers which will be added to the selected Stat use negitive numbers for negitive modifiers
    private int value;
    private int maxValue;

    //if time is 0 then modifier is applied until stat is unloaded. ie: end of game, game over, etc
    private float time;     //How long this modifier had been in effect
    private float duration;

    private bool expired = false;
    
    public StatModifier(StatModifierObject o, int v, int m, float d)
    {
        obj = o;
        value = v;
        maxValue = m;
        duration = d;
    }

    public IEnumerator Tick()
    {
        if (duration > 0)
        {
            while (time < duration)
            {
                time += Time.deltaTime;
                yield return null;
            }
            expired = true;
        }
    }

    public bool status()
    {
        return expired;
    }

    public int GetValue()
    {
        return value;
    }

    public int GetMaxValue()
    {
        return maxValue;
    }

    public float GetTimeLeft()
    {
        if(duration == 0)
        {
            return Mathf.Infinity;
        }
        else
        {
            return duration - time;
        }
    }

    public string GetModifierName()
    {
        return obj.modifierName;
    }
}
