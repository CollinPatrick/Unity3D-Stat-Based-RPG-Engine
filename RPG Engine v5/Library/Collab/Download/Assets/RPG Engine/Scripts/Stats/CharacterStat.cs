using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStat : BaseStat
{
    private int value;

    public CharacterStat(StatTypes s, int v) : base(s)
    {
        value = v;
    }

    public override int GetValue()
    {
        return value;
    }

    public override void SetValue(int v)
    {
        value = v;
    }
}
