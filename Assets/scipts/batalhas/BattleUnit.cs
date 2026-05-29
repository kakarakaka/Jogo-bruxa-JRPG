using System.Collections.Generic;
using UnityEngine;

public class BattleUnit :
    MonoBehaviour
{
    [Header("Tipo")]
    public bool isEnemy;

    [Header("Referências")]
    public CharacterStats characterStats;

    public EnemyStats enemyStats;

    [Header("Battle")]
    public int currentHP;

    public int bonusAttack;

    public int bonusDefense;

    public int bonusSpeed;

    public List<ActiveStatusEffect>
        activeEffects =
        new List<ActiveStatusEffect>();

    // =========================
    // INFO
    // =========================

    public string UnitName
    {
        get
        {
            if (isEnemy)
            {
                return enemyStats.enemyName;
            }

            return characterStats.characterName;
        }
    }

    public int MaxHP
    {
        get
        {
            if (isEnemy)
            {
                return enemyStats.maxHP;
            }

            return characterStats.maxHP;
        }
    }

    public int Attack
    {
        get
        {
            if (isEnemy)
            {
                return enemyStats.attack
                    + bonusAttack;
            }

            return characterStats.attack
                + bonusAttack;
        }
    }

    public int SpecialAttack
    {
        get
        {
            if (isEnemy)
            {
                return enemyStats
                    .specialAttack;
            }

            return characterStats
                .specialAttack;
        }
    }

    public int Defense
    {
        get
        {
            if (isEnemy)
            {
                return enemyStats.defense
                    + bonusDefense;
            }

            return characterStats.defense
                + bonusDefense;
        }
    }

    public int Speed
    {
        get
        {
            if (isEnemy)
            {
                return enemyStats.speed
                    + bonusSpeed;
            }

            return characterStats.speed
                + bonusSpeed;
        }
    }

    public List<Skill> EquippedSkills
    {
        get
        {
            if (isEnemy)
            {
                return enemyStats
                    .equippedSkills;
            }

            return characterStats.skills;
        }
    }

    // =========================
    // START
    // =========================

    void Start()
    {
        currentHP = MaxHP;
    }

    // =========================
    // DAMAGE
    // =========================

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        currentHP =
            Mathf.Max(currentHP, 0);

        Debug.Log(
            UnitName +
            " recebeu "
            + damage +
            " de dano!");
    }

    public bool IsDead()
    {
        return currentHP <= 0;
    }
}