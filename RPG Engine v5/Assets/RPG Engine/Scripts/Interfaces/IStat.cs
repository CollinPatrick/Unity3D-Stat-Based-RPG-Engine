using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStat
{
    StatTypes GetStatType();
    int GetValue();
    int GetMaxValue();
    void SetValue(int v);
    void SetMaxValue(int m);
    int GetGrowthRate();
    void SetGrowthRate(int gr);
}
