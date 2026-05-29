using TMPro;
using UnityEngine;

public class BattleTextUI :
    MonoBehaviour
{
    public TextMeshProUGUI textUI;

    private BattleUnit unit;

    // =========================
    // SETUP
    // =========================

    public void Setup(
        BattleUnit battleUnit)
    {
        unit = battleUnit;

        Refresh();
    }

    // =========================
    // REFRESH
    // =========================

    public void Refresh()
    {
        if (unit == null)
            return;

        // PLAYER
        if (!unit.isEnemy)
        {
            textUI.text =
                unit.UnitName
                + "\nHP: "
                + unit.currentHP
                + "/"
                + unit.MaxHP
                + "\nMP: "
                + unit.characterStats.maxMP
                + "/"
                + unit.characterStats.maxMP;
        }

        // ENEMY
        else
        {
            textUI.text =
                unit.UnitName
                + "\nHP: "
                + unit.currentHP
                + "/"
                + unit.MaxHP;
        }
    }
}