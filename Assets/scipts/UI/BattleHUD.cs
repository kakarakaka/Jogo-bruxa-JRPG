using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD :
    MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI nameText;

    public Slider hpSlider;

    public TextMeshProUGUI hpText;

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

        nameText.text =
            unit.UnitName;

        hpSlider.maxValue =
            unit.MaxHP;

        hpSlider.value =
            unit.currentHP;

        hpText.text =
            unit.currentHP
            + " / "
            + unit.MaxHP;
    }
}