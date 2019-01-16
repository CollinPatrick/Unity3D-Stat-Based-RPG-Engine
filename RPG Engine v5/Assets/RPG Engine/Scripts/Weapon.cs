using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "RPG Engine/Item/Weapon")]
public class Weapon : Item
{
    public WeaponTypes weaponType;
    public Elements elementAffinity;

    [SerializeField]
    public List<CharacterStat> statMods = new List<CharacterStat>
    {
        new CharacterStat(StatTypes.Strength, 0),
        new CharacterStat(StatTypes.Magic, 0),
        new CharacterStat(StatTypes.Agility, 0),
        new CharacterStat(StatTypes.Dexterity, 0),
        new CharacterStat(StatTypes.Defense, 0),
        new CharacterStat(StatTypes.Resistance, 0),
        new CharacterStat(StatTypes.Luck, 0),
    };
}
