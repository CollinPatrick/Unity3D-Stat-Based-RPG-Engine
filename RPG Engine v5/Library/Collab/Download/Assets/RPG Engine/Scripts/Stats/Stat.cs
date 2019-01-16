using System.Collections.Generic;
using UnityEngine;

//Container which holds data for each stat used by a character
[System.Serializable]
public class Stat
{
    private IStat stat;
    public List<StatModifier> statMods = new List<StatModifier>();  //Should make private in future. Force Remove stat mod is dependent on public

    public Stat(StatTypes s, int v, int m)
    {
        // (s == StatTypes.Health || s == StatTypes.SP)
        //{
            //stat = new ResourceStat(v, m, s);
        //}
        //else
        //{
            stat = new CharacterStat(s, v);
        //}
    }

    public StatTypes statType()
    {
        return stat.GetStatType();
    }

    public int StaticStatValue()
    {
        return stat.GetValue();
    }

    public int DynamicStatValue()
    {
        int value = StaticStatValue();
        int totalMods = 0;

        foreach (StatModifier mod in statMods)
        {
            totalMods += mod.GetValue();
        }

        return value + totalMods;
    }

    public int StaticStatMaxValue()
    {
        return stat.GetMaxValue();
    }

    public int DynamicStatMaxValue()
    {
        int value = StaticStatMaxValue();
        int totalMods = 0;

        foreach (StatModifier mod in statMods)
        {
            totalMods += mod.GetValue();
        }

        return value + totalMods;
    }

    public void AddModifier(StatModifier mod)
    {
        statMods.Add(mod);
    }

    public void AddStatPoints(int p)
    {
        stat.SetValue(stat.GetValue() + p);
    }

    public void SetGrowthRate(CharacterClass c, Bloodline bl, Boon bo, Bane ba)
    {
        //get total growthRate
        int gr = 0;
        foreach(BaseStat stat in c.GrowthRates)
        {
            if(stat.GetStatType() == statType())
            {
                gr += stat.GetGrowthRate();
                break;
            }
        }
        foreach (BaseStat stat in bl.GrowthRates)
        {
            if (stat.GetStatType() == statType())
            {
                gr += stat.GetGrowthRate();
                break;
            }
        }
        foreach (BaseStat stat in bo.GrowthRates)
        {
            if (stat.GetStatType() == statType())
            {
                gr += stat.GetGrowthRate();
                break;
            }
        }
        foreach (BaseStat stat in ba.GrowthRates)
        {
            if (stat.GetStatType() == statType())
            {
                gr += stat.GetGrowthRate();
                break;
            }
        }
        //Debug.Log(gr);
        stat.SetGrowthRate(gr);
    }

    public int GetGrowthRate()
    {
        return stat.GetGrowthRate();
    }

    //Checks if any stat modifiers expired and removes them
    public void CheckMods()
    {
        foreach(StatModifier mod in statMods)
        {
            if (mod.status())
            {
                statMods.Remove(mod);
                Debug.Log(statType().ToString() + " : " + DynamicStatValue());
                CheckMods();
                break;
            }
        }
    }
}
