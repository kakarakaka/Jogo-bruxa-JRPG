using System.Collections.Generic;
using UnityEngine;

public class EnemyStats :
    MonoBehaviour
{

    [Header("Info")]
    public string enemyName;

    public int level;

    [Header("Stats")]
    public int maxHP;

    public int attack;

    public int specialAttack;

    public int defense;

    public int speed;

    [Header("Skills")]
    public List<Skill>
        knownSkills =
        new List<Skill>();

    [HideInInspector]
    public List<Skill>
        equippedSkills =
        new List<Skill>();

    // =========================
    // RANDOMIZA STATUS
    // =========================

    public void GenerateStats()
    {
        level =
            Random.Range(1, 11);

        maxHP =
            50 + level * 15;

        attack =
            5 + level * 3;

        specialAttack =
            5 + level * 3;

        defense =
            3 + level * 2;

        speed =
            5 + level * 2;

        GenerateSkills();
    }

    // =========================
    // RANDOMIZA SKILLS
    // =========================

    void GenerateSkills()
    {
        equippedSkills.Clear();

        List<Skill> temp =
            new List<Skill>(
                knownSkills);

        int amount =
            Mathf.Min(
                Random.Range(4, 7),
                temp.Count);

        for (int i = 0;
            i < amount;
            i++)
        {
            int random =
                Random.Range(
                    0,
                    temp.Count);

            equippedSkills
                .Add(temp[random]);

            temp.RemoveAt(random);
        }
    }
}