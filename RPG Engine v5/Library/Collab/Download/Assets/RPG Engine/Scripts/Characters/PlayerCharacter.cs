using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class PlayerCharacter : BaseCharacter
{
    #region Testing
    public StatModifierObject testStatModObj;

    public Weapon testWeapon;

    private void Debugging()
    {
        foreach (Stat stat in stats)
        {
            Debug.Log(stat.statType().ToString() + " : " + stat.DynamicStatValue());
        }
    }
    #endregion

    #region Variables
    private List<Stat> stats = new List<Stat>();

    public IReadOnlyList<Stat> GetStats()
    {
        return stats.AsReadOnly();
    }

    private List<StatModifierObject> statModifiers = new List<StatModifierObject>();

    public IReadOnlyList<StatModifierObject> GetStatModifiers()
    {
        return statModifiers.AsReadOnly();
    }

    private int exp = 0;
    private int neededExpToLevel = 10;

    public int GetExp()
    {
        return exp;
    }
    public int GetNeededExp()
    {
        return neededExpToLevel;
    }

    public ClassTree classTree;

    private IReadOnlyList<Stat> GetAllStats()
    {
        return stats.AsReadOnly();
    }

    public Boon boon;

    public Bane bane;

    public List<Item> inventory = new List<Item>();

    #endregion

    #region Setup & Data Handling
    public void Setup(PlayerCharacter pc)
    {
        gold = pc.gold;
        stats = pc.stats;

        level = pc.level;
        exp = pc.exp;
        neededExpToLevel = pc.neededExpToLevel;

        //Inventory is retrieved from vault;

        boon = pc.boon;
        bane = pc.bane;
        bloodline = pc.bloodline;
        classTree = pc.classTree;
        characterClass = pc.characterClass;
        if(characterClass == null)
        {
            characterClass = classTree.root.characterClass;
        }
        //SetGrowthRates();
    }

    private void Awake()
    {
        PlayerCharacterData data = LoadCharacter();
        if (data == null)
        {
            stats = new List<Stat>
            {
                new Stat(StatTypes.Health, 0, 0),
                new Stat(StatTypes.SP, 0, 0),
                new Stat(StatTypes.Strength, 0, 0),
                new Stat(StatTypes.Magic, 0, 0),
                new Stat(StatTypes.Agility, 0, 0),
                new Stat(StatTypes.Dexterity, 0, 0),
                new Stat(StatTypes.Luck, 0, 0),
                new Stat(StatTypes.Defense, 0, 0),
                new Stat(StatTypes.Resistance, 0, 0),
                new Stat(StatTypes.Speed, 0, 0)
            };
            
            SetBaseStatPoints();
            SetGrowthRates();
            //FOR TESTING ONLY
            //AddStatModifierObject(Instantiate(testStatModObj) as StatModifierObject);
            inventory.Add(testWeapon);
            inventory.Add(testWeapon);
        }
        else
        {
            foreach (PlayerCharacter character in data.characters)
            {
                if (character.characterName == characterName)
                {
                    Setup(character);
                    break;
                }
            }
        }
    }

    //To prevent duplicate Items and different data between main inventory and character inventory, all items in player inventory
    //are only references to the item in the main inventory
    //STILL NEEDS TO BE IMPLIMENTED
    private void LoadInventory()
    {

    }

    //Save function moved elseware because it saves all characters
    private PlayerCharacterData LoadCharacter()
    {
        //CHANGE TO PERSISTANT DATA PATH AFTER TESTING!
        string filePath = Application.dataPath + "/SaveData/Characters/Charaters.dat";
        FileStream file;

        if (File.Exists(filePath)) file = File.OpenRead(filePath);
        else
        {
            Debug.LogError("Character Save File Not found");
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        PlayerCharacterData data = (PlayerCharacterData)bf.Deserialize(file);
        file.Close();

        return data;
    }

    #endregion

    #region Stats
    public void AddStatModifierObject(StatModifierObject obj)
    {
        statModifiers.Add(obj);

        foreach (statModifierGroup mod in obj.modifiers)
        {
            foreach (Stat stat in stats)
            {
                if (stat.statType() == mod.statType)
                {
                    StatModifier modifier = new StatModifier(Instantiate(obj), mod.value, mod.maxValue, mod.duration);
                    stat.AddModifier(modifier);
                    StartCoroutine(modifier.Tick());
                }
            }
        }

        StartCoroutine(obj.Tick());
    }

    private void CheckStatMods()
    {
        foreach (StatModifierObject obj in statModifiers)
        {
            if (obj.status())
            {
                Debug.Log(obj.modifierName + " Expired");
                statModifiers.Remove(obj);
                Destroy(obj);
                CheckStatMods();
                return;
            }
        }
    }

    //UNTESTED
    public void ForceRemoveStatModifier(StatModifierObject obj)
    {
        StatModifierObject modifier = null;

        foreach (StatModifierObject mod in statModifiers)
        {
            if (mod.modifierName == obj.name)
            {
                modifier = mod;
                break;
            }
        }
        if (modifier != null)
        {
            foreach (Stat stat in stats)
            {
                foreach (StatModifier mod in stat.statMods)
                {
                    if (mod.GetModifierName() == obj.modifierName)
                    {
                        stat.statMods.Remove(mod);
                        break;
                    }
                }
            }
        }
        else
        {
            Debug.Log(characterName + " Does not have " + obj.modifierName + " applied.");
            return;
        }
        statModifiers.Remove(modifier);
    }

    private void SetBaseStatPoints()
    {
        foreach (Stat stat in stats)
        {
            foreach(CharacterStat characterStat in characterClass.stats)
            {
                if(stat.statType() == characterStat.GetStatType())
                {
                    stat.AddStatPoints(characterStat.GetValue());
                }
            }
        }
    }

    #endregion

    #region Leveling
    //Run when class or subclass changes and upon default character setup;
    private void SetGrowthRates()
    {
        foreach (Stat stat in stats)
        {
            stat.SetGrowthRate(characterClass, bloodline, boon, bane);
        }
    }

    public void AddExp(int e)
    {
        exp += e;
        if(exp > neededExpToLevel)
        {
            StartCoroutine(LevelUp());
        }
    }

    private IEnumerator LevelUp()
    {
        while(exp > neededExpToLevel)
        {
            LevelUpDataSheet temp = new LevelUpDataSheet();
            foreach(Stat stat in stats)
            {
                temp.oldStats.Add(stat.StaticStatValue());
                stat.AddStatPoints(RollStat(stat.GetGrowthRate()));
                temp.curStats.Add(stat.StaticStatValue());
            }
            if(temp.oldStats != temp.curStats)//ensures at least one point is gained
            {
                exp -= neededExpToLevel;
                level++;
                neededExpToLevel += 10;
                GameSystem.levelManager.AddToQueue(temp);
                string Changes = "";
                for (int i = 0; i < stats.Count; i++)
                {
                    Changes += stats[i].statType() + " - " + (temp.curStats[i] - temp.oldStats[i]) + ", ";
                }
                Debug.Log("Level Log: " + Changes);
            }
            yield return null;
        }
    }

    private int RollStat(int gr)
    {
        int roll = Random.Range(1, 100);

        if(roll <= gr)
        {
            return 1 + RollStat(gr - gr / 3);
        }
        else
        {
            return 0;
        }
    }

    #endregion

    private void Update()
    {
        foreach (Stat stat in stats)
        {
            stat.CheckMods();
        }
        CheckStatMods();
    }

    private void Start()
    {
        AddExp(50);
        string temp = "UPGRADES: ";
        foreach (CharacterClass c in classTree.GetUpgrades(characterClass))
        {
            temp += c.className + ", ";
        }
        Debug.Log(temp);
        
        //Debug.Log("Fira -> Aguis : " + ElementComparer.GetMultiplier(Elements.Fira, Elements.Aguis));
        //Debug.Log("Glacia -> Fulga : " + ElementComparer.GetMultiplier(Elements.Glacia, Elements.Fulga));
        //Debug.Log("Tenebra -> Anemis : " + ElementComparer.GetMultiplier(Elements.Tenebra, Elements.Anemis));
    }
}

//MOVE TO OWN FILE
public class PlayerCharacterData
{
    public List<PlayerCharacter> characters;
}

public class LevelUpDataSheet
{
    public List<int> curStats = new List<int>();
    public List<int> oldStats = new List<int>();
}