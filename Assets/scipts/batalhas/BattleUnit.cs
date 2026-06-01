using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUnit : MonoBehaviour
{
    [Header("Tipo")]
    public bool isEnemy;

    [Header("Referências")]
    public CharacterStats characterStats;

    public EnemyStats enemyStats;

    [Header("Battle")]
    public int currentHP;

    public int currentMP;

    public int bonusAttack;

    public int bonusDefense;

    public int bonusSpeed;

    public List<ActiveStatusEffect>
        activeEffects =
        new List<ActiveStatusEffect>();


    void Start()
    {
        if (SceneManager
            .GetActiveScene()
            .name == "BattleScene")
        {
            Debug.Log(
                "Desativando scripts de mundo em: "
                + gameObject.name);

            DisableWorldScripts();
        }
    }

    void DisableWorldScripts()
    {
        MonoBehaviour[] scripts =
            GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            if (script == null)
                continue;

            if (script == this)
                continue;

            if (script is CharacterStats)
                continue;

            if (script is EnemyStats)
                continue;

            script.enabled = false;
        }
    }


    // =========================
    // INFO
    // =========================

    public string UnitName
    {
        get
        {
            if (isEnemy)
                return enemyStats.enemyName;

            return characterStats.characterName;
        }
    }

    public int MaxHP
    {
        get
        {
            if (isEnemy)
                return enemyStats.maxHP;

            return characterStats.maxHP;
        }
    }

    public int MaxMP
    {
        get
        {
            if (isEnemy)
                return 0;

            return characterStats.maxMP;
        }
    }

    public int Attack
    {
        get
        {
            if (isEnemy)
                return enemyStats.attack + bonusAttack;

            return characterStats.attack + bonusAttack;
        }
    }

    public int SpecialAttack
    {
        get
        {
            if (isEnemy)
                return enemyStats.specialAttack;

            return characterStats.specialAttack;
        }
    }

    public int Defense
    {
        get
        {
            if (isEnemy)
                return enemyStats.defense + bonusDefense;

            return characterStats.defense + bonusDefense;
        }
    }

    public int Speed
    {
        get
        {
            if (isEnemy)
                return enemyStats.speed + bonusSpeed;

            return characterStats.speed + bonusSpeed;
        }
    }

    public List<Skill> EquippedSkills
    {
        get
        {
            if (isEnemy)
                return enemyStats.equippedSkills;

            return characterStats.skills;
        }
    }

    // =========================
    // INICIALIZAÇÃO
    // =========================

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (isEnemy)
        {
            currentHP = MaxHP;

            return;
        }

        string id =
            characterStats.characterID;

        if (BattleData.savedHP.ContainsKey(id))
        {
            currentHP =
                BattleData.savedHP[id];
        }
        else
        {
            currentHP = MaxHP;

            BattleData.savedHP[id] =
                currentHP;
        }

        if (BattleData.savedMP.ContainsKey(id))
        {
            currentMP =
                BattleData.savedMP[id];
        }
        else
        {
            currentMP = MaxMP;

            BattleData.savedMP[id] =
                currentMP;
        }

        Debug.Log(
            UnitName +
            " carregado com HP "
            + currentHP +
            " MP "
            + currentMP);
    }

    // =========================
    // DAMAGE
    // =========================

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        currentHP =
            Mathf.Max(currentHP, 0);

        if (!isEnemy)
        {
            BattleData.savedHP[
                characterStats.characterID] =
                currentHP;
        }

        Debug.Log(
            UnitName +
            " recebeu " +
            damage +
            " de dano!");
    }

    // =========================
    // HEAL
    // =========================

    public void Heal(int amount)
    {
        currentHP += amount;

        currentHP =
            Mathf.Min(
                currentHP,
                MaxHP);

        if (!isEnemy)
        {
            BattleData.savedHP[
                characterStats.characterID] =
                currentHP;
        }
    }

    // =========================
    // MP
    // =========================

    public void UseMP(int amount)
    {
        if (isEnemy)
            return;

        currentMP -= amount;

        currentMP =
            Mathf.Max(
                currentMP,
                0);

        BattleData.savedMP[
            characterStats.characterID] =
            currentMP;
    }

    public void UseItem(
        ItemData item)
    {
        if (item == null)
            return;

        Heal(item.healHP);

        RecoverMP(item.healMP);
    }
    public void RecoverMP(int amount)
    {
        if (isEnemy)
            return;

        currentMP += amount;

        currentMP =
            Mathf.Min(
                currentMP,
                MaxMP);

        BattleData.savedMP[
            characterStats.characterID] =
            currentMP;
    }

    public bool HasEnoughMP(int amount)
    {
        if (isEnemy)
            return true;

        return currentMP >= amount;
    }

    // =========================
    // STATUS
    // =========================

    public void AddStatusEffect(
        ActiveStatusEffect effect)
    {
        activeEffects.Add(effect);
    }

    public void RemoveStatusEffect(
        ActiveStatusEffect effect)
    {
        activeEffects.Remove(effect);
    }

    // =========================
    // CHECKS
    // =========================

    public bool IsDead()
    {
        return currentHP <= 0;
    }
}