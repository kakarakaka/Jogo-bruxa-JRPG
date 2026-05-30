using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleSkillButton :
    MonoBehaviour,
    IPointerEnterHandler
{
    Skill skill;

    BattleSkillMenu menu;

    public TextMeshProUGUI buttonText;

    public Button button;

    public void Setup(
        Skill newSkill,
        BattleSkillMenu owner)
    {
        skill = newSkill;

        menu = owner;

        buttonText.text =
            skill.skillName;

        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(
            OnClick);
    }

    void OnClick()
    {
        menu.OnSkillSelected(skill);
    }

    public void OnPointerEnter(
        PointerEventData eventData)
    {
        menu.infoPanel.ShowSkill(skill);
    }
}