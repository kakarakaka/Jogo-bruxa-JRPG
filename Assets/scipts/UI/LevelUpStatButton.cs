using UnityEngine;
using UnityEngine.EventSystems;

public class LevelUpStatButton :
    MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public enum StatType
    {
        HP,
        MP,
        Attack,
        SpecialAttack
    }

    public StatType statType;

    public LevelUpUI levelUpUI;

    public void OnPointerEnter(
        PointerEventData eventData)
    {
        if (levelUpUI == null)
            return;

        switch (statType)
        {
            case StatType.HP:
                levelUpUI.PreviewHP();
                break;

            case StatType.MP:
                levelUpUI.PreviewMP();
                break;

            case StatType.Attack:
                levelUpUI.PreviewAttack();
                break;

            case StatType.SpecialAttack:
                levelUpUI.PreviewSpecialAttack();
                break;
        }
    }

    public void OnPointerExit(
        PointerEventData eventData)
    {
        if (levelUpUI == null)
            return;

        levelUpUI.RefreshUI();
    }
}