using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public Sprite sprite;

    public string itemName;

    public string description;

    public int value;

    public Rarities rarity;
}
