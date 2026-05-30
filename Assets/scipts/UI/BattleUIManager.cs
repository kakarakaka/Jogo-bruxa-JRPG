using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleUIManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI playerInfoText;

    public TextMeshProUGUI enemyInfoText;

    // =========================
    // REFRESH GERAL
    // =========================

    public void RefreshUI(
        List<BattleUnit> players,
        List<BattleUnit> enemies)
    {
        RefreshPlayers(players);

        RefreshEnemies(enemies);
    }

    // =========================
    // PLAYERS
    // =========================

    void RefreshPlayers(
        List<BattleUnit> players)
    {
        if (playerInfoText == null)
        {
            Debug.LogError(
                "Player Info Text não foi atribuído!");

            return;
        }

        string text = "";

        foreach (BattleUnit unit in players)
        {
            if (unit == null)
                continue;

            text += unit.UnitName;

            if (unit.IsDead())
            {
                text +=
                    "\n<color=red>KO</color>";
            }
            else
            {
                text +=
                    "\nHP: "
                    + unit.currentHP
                    + "/"
                    + unit.MaxHP;

                text +=
                    "\nMP: "
                    + unit.currentMP
                    + "/"
                    + unit.MaxMP;
            }

            text += "\n\n";
        }

        playerInfoText.text = text;
    }

    // =========================
    // ENEMIES
    // =========================

    void RefreshEnemies(
        List<BattleUnit> enemies)
    {
        if (enemyInfoText == null)
        {
            Debug.LogError(
                "Enemy Info Text não foi atribuído!");

            return;
        }

        string text = "";

        foreach (BattleUnit unit in enemies)
        {
            if (unit == null)
                continue;

            text += unit.UnitName;

            if (unit.IsDead())
            {
                text +=
                    "\n<color=red>KO</color>";
            }
            else
            {
                text +=
                    "\nHP: "
                    + unit.currentHP
                    + "/"
                    + unit.MaxHP;
            }

            text += "\n\n";
        }

        enemyInfoText.text = text;
    }
}