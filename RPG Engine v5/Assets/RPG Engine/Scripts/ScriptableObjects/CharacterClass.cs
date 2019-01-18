using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class", menuName = "RPG Engine/Class")]
public class CharacterClass : ScriptableObject
{
    public string className;
    public string description;
    public int tier = 0;    //Starts at 0

    [SerializeField]
    public List<BaseStat> GrowthRates = new List<BaseStat>
    {
        new BaseStat(StatTypes.Health, 0),
        //new BaseStat(StatTypes.SP, 0),
        new BaseStat(StatTypes.Strength, 0),
        new BaseStat(StatTypes.Magic, 0),
        new BaseStat(StatTypes.Agility, 0),
        new BaseStat(StatTypes.Dexterity, 0),
        new BaseStat(StatTypes.Defense, 0),
        new BaseStat(StatTypes.Resistance, 0),
        new BaseStat(StatTypes.Luck, 0),
    };

    [SerializeField]
    public List<CharacterStat> stats = new List<CharacterStat>
    {
        new CharacterStat(StatTypes.Health, 0),
        //new CharacterStat(StatTypes.SP, 0),
        new CharacterStat(StatTypes.Strength, 0),
        new CharacterStat(StatTypes.Magic, 0),
        new CharacterStat(StatTypes.Agility, 0),
        new CharacterStat(StatTypes.Dexterity, 0),
        new CharacterStat(StatTypes.Defense, 0),
        new CharacterStat(StatTypes.Resistance, 0),
        new CharacterStat(StatTypes.Luck, 0), 
    };

    public WeaponTypes weaponType;

    public Elements elementAffinity;

    //SKILLS
}
