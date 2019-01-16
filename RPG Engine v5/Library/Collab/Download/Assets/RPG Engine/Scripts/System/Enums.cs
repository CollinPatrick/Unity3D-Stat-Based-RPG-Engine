public enum StatTypes
{
    Health,     //Health
    SP,         //Special Points
    Strength,   //Physical Damage
    Magic,      //Elemental Damage
    Agility,    //Dodge
    Dexterity,  //Crit Damage Modifier
    Luck,       //Crit Chance/Crit Dodge
    Defense,    //Physical Defense
    Resistance, //Elemental Defense
    Speed       //Attack Speed (Who attacks first)
}

public enum Elements
{
    Fira,       //Fire
    Aguis,      //Water
    Jorra,      //Earth
    Anemis,     //Wind
    Fulga,      //Lightning
    Glacia,     //Ice
    Tenebra,    //Dark
    Sanctus,     //Light
    None
}

public enum ItemTypes
{
    Weapon,
    Consumable,
    Material,
    Charm,
    Gold
}

public enum WeaponTypes
{
    Sword,
    Hidden,
    Tome,
    Whip,
    Axe,
    Companion,
    Fist,
    Mace,
    Polearm,
    Bow,
    Daggar,
    Shapeshift,
    Staff

}

public enum StatusType
{
    Curse,      //Debuff
    Blessing    //Buff
}

public enum Rarities
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Ancient
}

//                   D E F E N D
//          
//           |  Fire    Water   Earth
//  A   _____|_______________________
//  T   Fire |  1       0.7     1.3 
//  T        |
//  A   Water|  1.3     1       0.7
//  C        |
//  K   Earth|  0.7     1.3     1
