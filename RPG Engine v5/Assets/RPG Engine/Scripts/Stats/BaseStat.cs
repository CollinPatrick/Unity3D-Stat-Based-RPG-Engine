using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStat : IStat
{
    private StatTypes stat; 

    private int growthRate = 0;

    public BaseStat(StatTypes s)
    {
        stat = s;
    }

    public BaseStat(StatTypes s, int gr)
    {
        stat = s;
        growthRate = gr;
    }

    public StatTypes GetStatType()
    {
        return stat;
    }

    public virtual int GetValue()
    {
        return 0;
    }

    public virtual int GetMaxValue()
    {
        return 0;
    }

    public virtual void SetValue(int v)
    {
        return;
    }

    public virtual void SetMaxValue(int m)
    {
        return;
    }

    public virtual int GetGrowthRate()
    {
        return growthRate;
    }

    public virtual void SetGrowthRate(int gr)
    {
        growthRate = gr;
    }
}
