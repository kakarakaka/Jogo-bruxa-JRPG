using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Progressão")]
    public int level = 1;


    [Header("ID")]
    public string characterID;

    [Header("Informações")]
    public string characterName;

    [Header("Status")]

    public int maxHP = 100;

    public int maxMP = 50;

    public int attack = 10;

    public int specialAttack = 15;

    public int defense = 0;

    public int speed = 8;

    [Header("Skills")]
    public List<Skill> skills =
        new List<Skill>();


    public int GetUpgradeCost()
    {
        return 100 + (level * 50);
    }

    void Awake()
    {
        AutoEquipSkills();
    }

    void AutoEquipSkills()
    {
        if (skills == null)
            return;

        int equippedCount = 0;

        foreach (Skill skill in skills)
        {
            if (skill == null)
                continue;

            skill.equipped = false;
        }

        for (int i = 0;
             i < skills.Count &&
             equippedCount < 4;
             i++)
        {
            if (skills[i] == null)
                continue;

            skills[i].equipped = true;

            equippedCount++;
        }
    }

    public enum UpgradeType
    {
        HP,
        MP,
        Attack,
        SpecialAttack
    }

   
}