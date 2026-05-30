using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillsMenu : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject skillButtonPrefab;

    [Header("Lista")]
    public Transform skillListParent;

    [Header("Painel")]
    public TextMeshProUGUI skillNameText;

    public TextMeshProUGUI damageText;

    public TextMeshProUGUI typeText;

    public TextMeshProUGUI descriptionText;

    [Header("Equip")]
    public Button equipButton;

    public TextMeshProUGUI equipButtonText;

    private CharacterStats currentCharacter;

    private Skill selectedSkill;

    // =========================
    // ABRIR SKILLS PERSONAGEM
    // =========================
    public void OpenCharacterSkills(GameObject character)
    {
        Debug.Log("CLICOU NO PERSONAGEM");

        // verifica personagem
        if (character == null)
        {
            Debug.LogError(
                "Character NULL!");
            return;
        }

        // pega CharacterStats
        currentCharacter =
            character.GetComponent<CharacterStats>();

        // verifica CharacterStats
        if (currentCharacter == null)
        {
            Debug.LogError(
                "CharacterStats não encontrado!");
            return;
        }

        Debug.Log(
            "Personagem selecionado: "
            + currentCharacter.characterName);

        // atualiza lista
        UpdateSkillList();
    }

    // =========================
    // CRIA BOTÕES DAS SKILLS
    // =========================
    void UpdateSkillList()
    {
        Debug.Log(
            "UpdateSkillList iniciou");

        // verifica parent
        if (skillListParent == null)
        {
            Debug.LogError(
                "skillListParent NULL!");
            return;
        }

        // verifica prefab
        if (skillButtonPrefab == null)
        {
            Debug.LogError(
                "skillButtonPrefab NULL!");
            return;
        }

        // verifica personagem
        if (currentCharacter == null)
        {
            Debug.LogError(
                "currentCharacter NULL!");
            return;
        }

        Debug.Log(
            "Quantidade de skills: "
            + currentCharacter.skills.Count);

        // limpa lista antiga
        foreach (Transform child in skillListParent)
        {
            Destroy(child.gameObject);
        }

        // cria botões
        foreach (Skill skill in currentCharacter.skills)
        {
            Debug.Log(
                "Criando botão: "
                + skill.skillName);

            GameObject button =
                Instantiate(
                    skillButtonPrefab,
                    skillListParent
                );

            button.SetActive(true);

            SkillButtonUI ui =
                button.GetComponent<SkillButtonUI>();

            // verifica script
            if (ui == null)
            {
                Debug.LogError(
                    "SkillButtonUI não encontrado!");
                continue;
            }

            // configura botão
            ui.Setup(skill, this);

            Debug.Log(
                "Botão criado com sucesso");
        }
    }

    // =========================
    // SELECIONA SKILL
    // =========================
    public void SelectSkill(Skill skill)
    {
        Debug.Log(this.gameObject.name);

        Debug.Log("SELECTSKILL FOI CHAMADO");

        if (skill == null)
        {
            Debug.LogError("SKILL NULL");
            return;
        }

        selectedSkill = skill;

        Debug.Log(skill.skillName);

        if (skillNameText != null)
        {
            Debug.Log("Atualizando nome");

            skillNameText.text =
                skill.skillName;
        }
        else
        {
            Debug.LogError(
                "skillNameText NULL");
        }

        if (damageText != null)
        {
            damageText.text =
                "Dano: " + skill.damage;
        }

        if (typeText != null)
        {
            typeText.text =
     "Tipo: " +
     skill.skillType.ToString();
        }

        if (descriptionText != null)
        {
            descriptionText.text =
                skill.description;
        }

        if (equipButtonText != null)
        {
            equipButtonText.text =
                skill.equipped
                ? "Desequipar"
                : "Equipar";
        }
    }

    // =========================
    // EQUIPAR / DESEQUIPAR
    // =========================
    public void ToggleEquipSkill()
    {
        if (selectedSkill == null)
        {
            Debug.LogWarning(
                "Nenhuma skill selecionada!");
            return;
        }

        // equipar
        if (!selectedSkill.equipped)
        {
            int equippedCount = 0;

            foreach (Skill skill
                in currentCharacter.skills)
            {
                if (skill.equipped)
                {
                    equippedCount++;
                }
            }

            // limite
            if (equippedCount >= 4)
            {
                Debug.Log(
                    "Máximo de 4 golpes!");
                return;
            }

            selectedSkill.equipped = true;
        }

        // desequipar
        else
        {
            int equippedCount = 0;

            foreach (Skill skill in currentCharacter.skills)
            {
                if (skill.equipped)
                    equippedCount++;
            }

            if (equippedCount <= 1)
            {
                Debug.Log(
                    "O personagem precisa ter pelo menos 1 golpe equipado.");

                return;
            }

            selectedSkill.equipped = false;
        }

        // atualiza UI
        SelectSkill(selectedSkill);

        UpdateSkillList();
    }
}