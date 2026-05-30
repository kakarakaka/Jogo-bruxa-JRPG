using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [Header("Units")]
    public List<BattleUnit> players =
        new List<BattleUnit>();

    public List<BattleUnit> enemies =
        new List<BattleUnit>();

    [Header("Systems")]
    public TurnManager turnManager;

    public EnemyAI enemyAI;

    [Header("UI")]
    public BattleUIManager uiManager;

    public BattleSkillMenu skillMenu;

    public BattleTargetMenu targetMenu;

    public BattleLogUI battleLog;

    private BattleUnit currentUnit;

    private Skill selectedSkill;

    // =========================
    // START
    // =========================

    void Start()
    {
        BattleSpawner spawner =
            FindFirstObjectByType<BattleSpawner>();

        if (spawner == null)
        {
            Debug.LogError(
                "BattleSpawner NULL!");

            return;
        }

        players = spawner.playerUnits;
        enemies = spawner.enemyUnits;

        Debug.Log(
            "Players encontrados: "
            + players.Count);

        Debug.Log(
            "Enemies encontrados: "
            + enemies.Count);

        SetupBattle();
    }

    // =========================
    // SETUP
    // =========================

    void SetupBattle()
    {
        if (turnManager == null)
        {
            Debug.LogError(
                "TurnManager NULL!");

            return;
        }

        turnManager.units.Clear();

        foreach (BattleUnit unit in players)
        {
            if (unit != null)
            {
                turnManager.units.Add(unit);
            }
        }

        foreach (BattleUnit unit in enemies)
        {
            if (unit != null)
            {
                turnManager.units.Add(unit);
            }
        }

        turnManager.GenerateTurnOrder();

        if (uiManager != null)
        {
            uiManager.RefreshUI(
                players,
                enemies);
        }

        NextTurn();
    }

    // =========================
    // TURNOS
    // =========================

    public void NextTurn()
    {
        Debug.Log("NEXT TURN");

        RemoveDeadUnits();

        if (CheckBattleEnd())
        {
            Debug.Log(
                "Batalha encerrada");

            return;
        }

        currentUnit =
            turnManager.GetNextTurn();

        if (currentUnit == null)
        {
            Debug.LogError(
                "Current Unit NULL!");

            return;
        }

        StatusEffectManager
            .ProcessEffects(
                currentUnit);

        RemoveDeadUnits();

        if (CheckBattleEnd())
        {
            return;
        }

        if (currentUnit.IsDead())
        {
            Debug.Log(
                currentUnit.UnitName +
                " morreu antes de agir.");

            currentUnit =
                turnManager.GetNextTurn();

            if (currentUnit == null)
            {
                Debug.LogError(
                    "Nenhuma unidade válida encontrada!");

                return;
            }
        }

        Debug.Log(
            "Turno de: "
            + currentUnit.UnitName);

        if (currentUnit.isEnemy)
        {
            EnemyTurn();
        }
        else
        {
            PlayerTurn();
        }
    }

    // =========================
    // PLAYER TURN
    // =========================

    void PlayerTurn()
    {
        Debug.Log(
            "PLAYER TURN");

        if (battleLog != null)
        {
            battleLog.Write(
                "Turno de "
                + currentUnit.UnitName);
        }

        if (skillMenu != null)
        {
            skillMenu.gameObject.SetActive(true);

            skillMenu.ShowSkills(
                currentUnit);
        }

        if (targetMenu != null)
        {
            targetMenu.Hide();
        }
    }

    // =========================
    // SKILL ESCOLHIDA
    // =========================

    public void SelectSkill(
        Skill skill)
    {
        if (skill == null)
        {
            Debug.LogError(
                "Skill NULL!");

            return;
        }

        selectedSkill = skill;

        if (battleLog != null)
        {
            battleLog.Write(
                "Escolha um alvo para "
                + skill.skillName);
        }

        if (targetMenu != null)
        {
            targetMenu.ShowTargets(
                enemies);
        }
    }

    // =========================
    // USAR SKILL
    // =========================

    public void UseSkillOnTarget(
        BattleUnit target)
    {
        if (selectedSkill == null)
        {
            Debug.LogError(
                "Nenhuma skill selecionada!");

            return;
        }

        if (target == null)
        {
            Debug.LogError(
                "Alvo NULL!");

            return;
        }

        int damage =
            DamageCalculator
            .CalculateDamage(
                currentUnit,
                target,
                selectedSkill);

        target.TakeDamage(damage);

        StatusEffectManager
            .ApplyEffect(
                target,
                selectedSkill);

        string log =
            currentUnit.UnitName +
            " usou " +
            selectedSkill.skillName +
            "\n" +
            target.UnitName +
            " sofreu " +
            damage +
            " de dano.";

        if (selectedSkill.effectType !=
            StatusEffectType.None)
        {
            log +=
                "\nStatus aplicado: "
                + selectedSkill.effectType;
        }

        if (battleLog != null)
        {
            battleLog.Write(log);
        }

        RemoveDeadUnits();

        if (uiManager != null)
        {
            uiManager.RefreshUI(
                players,
                enemies);
        }

        selectedSkill = null;

        if (targetMenu != null)
        {
            targetMenu.Hide();
        }

        if (CheckBattleEnd())
        {
            return;
        }

        NextTurn();
    }

    // =========================
    // ENEMY TURN
    // =========================

    void EnemyTurn()
    {
        Debug.Log(
            "ENEMY TURN");

        if (players.Count <= 0)
        {
            Debug.LogError(
                "Não existem jogadores!");

            return;
        }

        BattleUnit target =
            players[
                Random.Range(
                    0,
                    players.Count)];

        Skill skill =
            enemyAI.ChooseSkill(
                currentUnit);

        if (skill == null)
        {
            Debug.LogError(
                "Enemy sem skill!");

            return;
        }

        int damage =
            DamageCalculator
            .CalculateDamage(
                currentUnit,
                target,
                skill);

        target.TakeDamage(damage);

        StatusEffectManager
            .ApplyEffect(
                target,
                skill);

        string log =
            currentUnit.UnitName +
            " usou " +
            skill.skillName +
            "\n" +
            target.UnitName +
            " sofreu " +
            damage +
            " de dano.";

        if (skill.effectType !=
            StatusEffectType.None)
        {
            log +=
                "\nStatus aplicado: "
                + skill.effectType;
        }

        if (battleLog != null)
        {
            battleLog.Write(log);
        }

        RemoveDeadUnits();

        if (uiManager != null)
        {
            uiManager.RefreshUI(
                players,
                enemies);
        }

        if (CheckBattleEnd())
        {
            return;
        }

        NextTurn();
    }

    // =========================
    // REMOVER MORTOS
    // =========================

    void RemoveDeadUnits()
    {
        players.RemoveAll(
            unit =>
            unit == null ||
            unit.IsDead());

        enemies.RemoveAll(
            unit =>
            unit == null ||
            unit.IsDead());

        if (turnManager != null)
        {
            turnManager.units.RemoveAll(
                unit =>
                unit == null ||
                unit.IsDead());
        }
    }

    // =========================
    // FIM DA BATALHA
    // =========================

    bool CheckBattleEnd()
    {
        if (enemies.Count <= 0)
        {
            Debug.Log(
                "Vitória!");

            return true;
        }

        if (players.Count <= 0)
        {
            Debug.Log(
                "Derrota!");

            return true;
        }

        return false;
    }

    // =========================
    // REFRESH UI
    // =========================

    public void RefreshBattleUI()
    {
        if (uiManager != null)
        {
            uiManager.RefreshUI(
                players,
                enemies);
        }
    }
}