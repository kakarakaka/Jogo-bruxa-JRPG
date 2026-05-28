using TMPro;
using UnityEngine;

public class StatusMenu : MonoBehaviour
{
    [Header("Textos")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;

    public TextMeshProUGUI attackText;
    public TextMeshProUGUI specialAttackText;

    public TextMeshProUGUI speedText;

    public void ShowCharacterStatus(GameObject character)
    {
        CharacterStats stats =
            character.GetComponent<CharacterStats>();

        if (stats == null)
            return;

        nameText.text =
            "Nome: " + stats.characterName;

        levelText.text =
            "Level: " + stats.level;

        hpText.text =
            "Max HP: " + stats.maxHP;

        mpText.text =
            "Max MP: " + stats.maxMP;

        attackText.text =
            "Ataque: " + stats.attack;

        specialAttackText.text =
            "Esp. Ataque: " +
            stats.specialAttack;

        speedText.text =
            "speed: " + stats.speed;
    }
}