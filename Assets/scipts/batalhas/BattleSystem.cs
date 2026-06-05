using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BattleSystem : MonoBehaviour
{
    [Header("Scenes")]
    public string worldSceneName = "Mapa";
    public string gameOverSceneName = "GameOver";

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

    private List<BattleUnit> battleEnemies =
    new List<BattleUnit>();

    IEnumerator EndEnemyTurn()
    {
        while (battleLog != null &&
               battleLog.IsShowingMessage)
        {
            yield return null;
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
            yield break;
        }

        NextTurn();
    }



    // =========================
    // START
    // =========================

    void Start()
    {
    

        battleEnemies = new List<BattleUnit>(enemies);

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
        battleEnemies = new List<BattleUnit>(enemies);

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
        if (currentUnit == null)
        {
            NextTurn();
            return;
        }

        if (currentUnit.IsDead())
        {
            Debug.Log(
                currentUnit.UnitName +
                " está morto.");

            NextTurn();
            return;
        }

        if (CheckBattleEnd())
        {
            return;
        }

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

        if (currentUnit == null)
            return;

        if (currentUnit.IsDead())
            return;

        if (CheckBattleEnd())
            return;

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

        RemoveDeadUnits();

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

        List<BattleUnit> alivePlayers =
            new List<BattleUnit>();

        foreach (BattleUnit player in players)
        {
            if (player != null &&
                !player.IsDead())
            {
                alivePlayers.Add(player);
            }
        }

        if (alivePlayers.Count <= 0)
        {
            Debug.LogError(
                "Não existem jogadores vivos!");

            return;
        }

        BattleUnit target =
            alivePlayers[
                Random.Range(
                    0,
                    alivePlayers.Count)];

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

        Debug.Log(
            "LOG INIMIGO:\n" +
            log);

        if (battleLog != null)
        {
            battleLog.Write(log);
        }

        StartCoroutine(
    EndEnemyTurn());
    }

    // =========================
    // REMOVER MORTOS
    // =========================

    void RemoveDeadUnits()
    {
        // Mantém jogadores mortos para exibir KO na UI
        players.RemoveAll(
            unit =>
            unit == null);

        // Remove inimigos derrotados
        enemies.RemoveAll(
            unit =>
            unit == null ||
            unit.IsDead());

        // Remove mortos da fila de turnos
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
        bool allPlayersDead = true;

        foreach (BattleUnit player in players)
        {
            if (player != null &&
                !player.IsDead())
            {
                allPlayersDead = false;
                break;
            }
        }

        if (enemies.Count <= 0)
        {
            Debug.Log("Vitória!");

            WinBattle();

            return true;
        }

        if (allPlayersDead)
        {
            Debug.Log("Derrota!");

            LoseBattle();

            return true;
        }

        return false;
    }

    void WinBattle()
    {
        Debug.Log("Vitória!");

        if (!string.IsNullOrEmpty(
            BattleData.currentEnemyID))
        {
            BattleData.defeatedEnemies.Add(
                BattleData.currentEnemyID);

            Debug.Log(
                "Inimigo derrotado: "
                + BattleData.currentEnemyID);
        }

        GiveBattleGold();

        SceneManager.LoadScene(
            worldSceneName);

        SceneManager.LoadScene(
            worldSceneName);
    }

    void LoseBattle()
    {
        Debug.Log("Game Over");

        SceneManager.LoadScene(
            gameOverSceneName);
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

    void GiveBattleGold()
    {
        int totalGold = 0;

        foreach (BattleUnit enemy in battleEnemies)
        {
            if (enemy == null)
                continue;

            totalGold +=
                enemy.enemyStats.level * 150;
        }

        BattleData.gold += totalGold;
    }

}