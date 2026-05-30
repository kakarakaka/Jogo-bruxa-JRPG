using TMPro;
using UnityEngine;

public class BattleTextUI : MonoBehaviour
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
        if (textUI == null)
            return;

        if (unit == null)
        {
            textUI.text = "";
            return;
        }

        // PLAYER
        if (!unit.isEnemy)
        {
            string status = "";

            if (unit.IsDead())
            {
                status = "\nKO";
            }

            textUI.text =
                unit.UnitName
                + "\nHP: "
                + unit.currentHP
                + "/"
                + unit.MaxHP
                + "\nMP: "
                + unit.currentMP
                + "/"
                + unit.MaxMP
                + status;
        }

        // ENEMY
        else
        {
            string status = "";

            if (unit.IsDead())
            {
                status = "\nDERROTADO";
            }

            textUI.text =
                unit.UnitName
                + "\nHP: "
                + unit.currentHP
                + "/"
                + unit.MaxHP
                + status;
        }
    }
}