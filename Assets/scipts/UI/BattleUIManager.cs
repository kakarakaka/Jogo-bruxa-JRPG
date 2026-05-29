using System.Collections.Generic;
using UnityEngine;

public class BattleUIManager :
    MonoBehaviour
{
    [Header("Panels")]
    public Transform playerPanel;

    public Transform enemyPanel;

    [Header("Prefabs")]
    public GameObject textPrefab;

    private Dictionary
        <BattleUnit, BattleTextUI>
        texts =
        new Dictionary
        <BattleUnit, BattleTextUI>();

    // =========================
    // CREATE UI
    // =========================

    public void CreateUI(
        List<BattleUnit> players,
        List<BattleUnit> enemies)
    {
        // PLAYERS
        foreach (BattleUnit unit
            in players)
        {
            GameObject obj =
                Instantiate(
                    textPrefab,
                    playerPanel);

            BattleTextUI ui =
                obj.GetComponent
                <BattleTextUI>();

            ui.Setup(unit);

            texts.Add(unit, ui);
        }

        // ENEMIES
        foreach (BattleUnit unit
            in enemies)
        {
            GameObject obj =
                Instantiate(
                    textPrefab,
                    enemyPanel);

            BattleTextUI ui =
                obj.GetComponent
                <BattleTextUI>();

            ui.Setup(unit);

            texts.Add(unit, ui);
        }
    }

    // =========================
    // REFRESH
    // =========================

    public void RefreshUnit(
        BattleUnit unit)
    {
        if (texts.ContainsKey(unit))
        {
            texts[unit].Refresh();
        }
    }
}