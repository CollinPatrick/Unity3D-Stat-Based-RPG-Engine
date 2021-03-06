﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boon", menuName = "RPG Engine/Boon")]
public class Boon : ScriptableObject
{
    public string boonName;
    public string description;

    [SerializeField]
    public List<BaseStat> GrowthRates = new List<BaseStat>
    {
        new BaseStat(StatTypes.Health, 0),
        new BaseStat(StatTypes.SP, 0),
        new BaseStat(StatTypes.Strength, 0),
        new BaseStat(StatTypes.Magic, 0),
        new BaseStat(StatTypes.Agility, 0),
        new BaseStat(StatTypes.Dexterity, 0),
        new BaseStat(StatTypes.Defense, 0),
        new BaseStat(StatTypes.Resistance, 0),
        new BaseStat(StatTypes.Luck, 0),
    };
}
