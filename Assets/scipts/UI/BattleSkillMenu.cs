using UnityEngine;

public class BattleSkillMenu : MonoBehaviour
{
    public GameObject skillButtonPrefab;
    public Transform content;
    public SkillInfoPanel infoPanel;

    BattleUnit currentUnit;
    BattleSystem battleSystem;

    void Start()
    {
        battleSystem =
            FindFirstObjectByType<BattleSystem>();
    }

    public void OnSkillSelected(Skill skill)
    {
        if (battleSystem == null)
            return;

        battleSystem.SelectSkill(skill);
    }

    public void ShowSkills(BattleUnit unit)
    {
        currentUnit = unit;

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        if (unit == null)
            return;

        foreach (Skill skill in unit.EquippedSkills)
        {
            if (skill == null)
                continue;

            if (!skill.equipped)
                continue;

            GameObject obj =
                Instantiate(
                    skillButtonPrefab,
                    content);

            BattleSkillButton button =
                obj.GetComponent<BattleSkillButton>();

            if (button != null)
            {
                button.Setup(
                    skill,
                    this);
            }
        }
    }
}