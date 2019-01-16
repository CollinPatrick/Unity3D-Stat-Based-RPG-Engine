using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class Tree", menuName = "RPG Engine/Class Tree")]
public class ClassTree : ScriptableObject
{
    //public CharacterClass currentClass;
    public ClassTreeRoot root = new ClassTreeRoot();

    public List<CharacterClass> GetUpgrades(CharacterClass c)
    {
        List<CharacterClass> upgrades = new List<CharacterClass>();

        if (root.characterClass == c)
        {
            foreach (ClassTreeTierTwo t2 in root.branches)
            {
                upgrades.Add(t2.characterClass);
            }
            return upgrades;
        }
        else
        {
            foreach (ClassTreeTierTwo t2 in root.branches)
            {
                if (t2.characterClass == c)
                {
                    foreach (ClassTreeTierThree t3 in t2.branches)
                    {
                        upgrades.Add(t3.characterClass);
                    }
                    return upgrades;
                }
            }
        }
        return null;
    }

    public List<CharacterClass> GetLineage(CharacterClass c)
    {
        List<CharacterClass> lineage = new List<CharacterClass>();
        lineage.Add(root.characterClass);

        if (root.characterClass == c)
        {     
            return lineage;
        }

        for (int i = 0; i < root.branches.Count; i++)
        {
            if(root.branches[i].characterClass == c)
            {
                lineage.Add(root.branches[i].characterClass);
                return lineage;
            }
            for (int j = 0; j < root.branches[i].branches.Count; j++)
            {
                if(root.branches[i].branches[j].characterClass == c)
                {
                    lineage.Add(root.branches[i].characterClass);
                    lineage.Add(root.branches[i].branches[j].characterClass);
                    return lineage;
                }
            }
        }
        return null;
    }
}

[System.Serializable]
public class ClassTreeRoot
{
    public CharacterClass characterClass;
    public List<ClassTreeTierTwo> branches = new List<ClassTreeTierTwo>
    {
        new ClassTreeTierTwo(),
        new ClassTreeTierTwo(),
        new ClassTreeTierTwo()
    };
}

[System.Serializable]
public class ClassTreeTierTwo
{
    public CharacterClass characterClass;
    public List<ClassTreeTierThree> branches = new List<ClassTreeTierThree>
    {
        new ClassTreeTierThree(),
        new ClassTreeTierThree()
    };
}

[System.Serializable]
public class ClassTreeTierThree
{
    public CharacterClass characterClass;
}