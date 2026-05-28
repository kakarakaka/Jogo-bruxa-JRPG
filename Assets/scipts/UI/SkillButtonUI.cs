using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillButtonUI :
    MonoBehaviour,
    IPointerClickHandler
{
    [Header("UI")]
    public TextMeshProUGUI skillNameText;

    public Image background;

    private Skill skill;

    private SkillsMenu skillsMenu;

    public void Setup(
        Skill newSkill,
        SkillsMenu menu)
    {
        Debug.Log("Setup executado");

        skill = newSkill;

        skillsMenu = menu;

        if (skillNameText != null)
        {
            skillNameText.text =
                skill.skillName;
        }

        UpdateVisual();
    }

    void UpdateVisual()
    {
        if (background != null)
        {
            Color color =
                background.color;

            color.a =
                skill.equipped
                ? 1f
                : 0.4f;

            background.color = color;
        }
    }

    // =========================
    // CLIQUE DO BOTÃO
    // =========================
    public void OnPointerClick(
        PointerEventData eventData)
    {
        Debug.Log("CLICOU NA SKILL");

        if (skillsMenu == null)
        {
            Debug.LogError(
                "SkillsMenu NULL!");
            return;
        }

        if (skill == null)
        {
            Debug.LogError(
                "Skill NULL!");
            return;
        }

        skillsMenu.SelectSkill(skill);
    }
}