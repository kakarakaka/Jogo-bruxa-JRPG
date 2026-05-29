using System.Collections.Generic;
using UnityEngine;

public class BattleSystem :
    MonoBehaviour
{
    [Header("Units")]
    public List<BattleUnit>
        players =
        new List<BattleUnit>();

    public List<BattleUnit>
        enemies =
        new List<BattleUnit>();

    [Header("Systems")]
    public TurnManager turnManager;

    public EnemyAI enemyAI;

    private BattleUnit currentUnit;

    public BattleUIManager uiManager;

    void Start()
    {
        BattleSpawner spawner =
    FindFirstObjectByType
    <BattleSpawner>();

        if (spawner == null)
        {
            Debug.LogError(
                "BattleSpawner NULL!");

            return;
        }

        players =
            spawner.playerUnits;

        enemies =
            spawner.enemyUnits;

        SetupBattle();
    }

    // =========================
    // SETUP
    // =========================

    void SetupBattle()
    {
        turnManager.units.Clear();

        foreach (BattleUnit unit in players)
        {
            turnManager.units.Add(unit);
        }

        foreach (BattleUnit unit in enemies)
        {
            turnManager.units.Add(unit);
        }

        turnManager.GenerateTurnOrder();

        uiManager.CreateUI(
    players,
    enemies);

        NextTurn();
    }

    // =========================
    // NEXT TURN
    // =========================

    public void NextTurn()
    {
        currentUnit =
            turnManager.GetNextTurn();

        if (currentUnit == null)
        {
            Debug.LogError(
                "Current Unit NULL!");

            return;
        }

        Debug.Log(
            "Turno de: "
            + currentUnit.UnitName);

        // inimigo
        if (currentUnit.isEnemy)
        {
            EnemyTurn();
        }

        // player
        else
        {
            PlayerTurn();
        }
    }

    // =========================
    // PLAYER
    // =========================

    void PlayerTurn()
    {
        Debug.Log(
            "Esperando player...");
    }

    // =========================
    // ENEMY
    // =========================

    void EnemyTurn()
    {
        BattleUnit target =
            players[
                Random.Range(
                    0,
                    players.Count)];

        Skill skill =
            enemyAI.ChooseSkill(
                currentUnit);

        int damage =
            DamageCalculator
            .CalculateDamage(
                currentUnit,
                target,
                skill);

        target.TakeDamage(damage);

        uiManager.RefreshUnit(
    target);

        Debug.Log(
            currentUnit.UnitName +
            " usou "
            + skill.skillName);

        NextTurn();
    }
}