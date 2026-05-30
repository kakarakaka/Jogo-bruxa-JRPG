using TMPro;
using UnityEngine;

public class SkillInfoPanel :
    MonoBehaviour
{
    public TextMeshProUGUI skillNameText;

    public TextMeshProUGUI damageText;

    public TextMeshProUGUI typeText;

    public TextMeshProUGUI statusText;


    public void ShowSkill(
        Skill skill)
    {
        skillNameText.text =
            skill.skillName;

        damageText.text =
            "Dano: " +
            skill.damage;

        typeText.text =
            "Tipo: " +
            skill.skillType;

        statusText.text =
    "Status: " +
    skill.effectType;


    }
}