using TMPro;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    [Header("Textos")]
    public TextMeshProUGUI currentStatsText;

    public TextMeshProUGUI previewStatsText;

    public TextMeshProUGUI goldText;

    public TextMeshProUGUI costText;

    private CharacterStats selectedCharacter;

    private int pendingHP;
    private int pendingMP;
    private int pendingAttack;
    private int pendingSpecialAttack;

    private int pendingLevels;
    private int pendingCost;

    void OnEnable()
    {
        SelectCharacter(0);
    }

    public void SelectCharacter(int index)
    {
        if (PartyManager.Instance == null)
            return;

        if (index >=
            PartyManager.Instance.currentParty.Count)
            return;

        GameObject member =
            PartyManager.Instance.currentParty[index];

        if (member == null)
            return;

        selectedCharacter =
            member.GetComponent<CharacterStats>();

        CancelChanges();

        RefreshUI();
    }

    int GetLevelCost(int level)
    {
        return 100 +
               (level * level * 25);
    }

    public void AddHP()
    {
        AddUpgrade(
            selectedCharacter.level +
            pendingLevels);

        pendingHP += 10;

        RefreshUI();
    }

    public void AddMP()
    {
        AddUpgrade(
            selectedCharacter.level +
            pendingLevels);

        pendingMP += 5;

        RefreshUI();
    }

    public void AddAttack()
    {
        AddUpgrade(
            selectedCharacter.level +
            pendingLevels);

        pendingAttack += 2;

        RefreshUI();
    }

    public void AddSpecialAttack()
    {
        AddUpgrade(
            selectedCharacter.level +
            pendingLevels);

        pendingSpecialAttack += 2;

        RefreshUI();
    }

    void AddUpgrade(int currentLevel)
    {
        pendingCost +=
            GetLevelCost(currentLevel);

        pendingLevels++;
    }

    public void ConfirmChanges()
    {
        if (selectedCharacter == null)
            return;

        if (BattleData.gold <
            pendingCost)
        {
            Debug.Log(
                "Gold insuficiente!");

            return;
        }

        BattleData.gold -=
            pendingCost;

        selectedCharacter.maxHP +=
            pendingHP;

        selectedCharacter.maxMP +=
            pendingMP;

        selectedCharacter.attack +=
            pendingAttack;

        selectedCharacter.specialAttack +=
            pendingSpecialAttack;

        int speedIncrease =
            pendingLevels / 2;

        selectedCharacter.speed +=
            speedIncrease;

        selectedCharacter.level +=
            pendingLevels;

        CancelChanges();

        RefreshUI();
    }

    public void CancelChanges()
    {
        pendingHP = 0;

        pendingMP = 0;

        pendingAttack = 0;

        pendingSpecialAttack = 0;

        pendingLevels = 0;

        pendingCost = 0;

        RefreshUI();
    }

    public void PreviewHP()
    {
        ShowPreview(
            10,
            0,
            0,
            0);
    }

    public void PreviewMP()
    {
        ShowPreview(
            0,
            5,
            0,
            0);
    }

    public void PreviewAttack()
    {
        ShowPreview(
            0,
            0,
            2,
            0);
    }

    public void PreviewSpecialAttack()
    {
        ShowPreview(
            0,
            0,
            0,
            2);
    }

    void ShowPreview(
        int hp,
        int mp,
        int atk,
        int satk)
    {
        if (selectedCharacter == null)
            return;

        int finalLevel =
            selectedCharacter.level +
            pendingLevels + 1;

        int finalSpeed =
            selectedCharacter.speed +
            ((pendingLevels + 1) / 2);

        previewStatsText.text =
            "Nível: " +
            finalLevel +
            "\n\nHP: " +
            (selectedCharacter.maxHP +
            pendingHP + hp) +
            "\nMP: " +
            (selectedCharacter.maxMP +
            pendingMP + mp) +
            "\nATK: " +
            (selectedCharacter.attack +
            pendingAttack + atk) +
            "\nSATK: " +
            (selectedCharacter.specialAttack +
            pendingSpecialAttack + satk) +
            "\nSPD: " +
            finalSpeed;
    }

    public void RefreshUI()
    {
        if (selectedCharacter == null)
            return;

        goldText.text =
            "Dinheiro: " +
            BattleData.gold;

        costText.text =
            "Custo: " +
            pendingCost;

        currentStatsText.text =
            "Nível: " +
            selectedCharacter.level +
            "\n\nHP: " +
            selectedCharacter.maxHP +
            "\nMP: " +
            selectedCharacter.maxMP +
            "\nATK: " +
            selectedCharacter.attack +
            "\nSATK: " +
            selectedCharacter.specialAttack +
            "\nSPD: " +
            selectedCharacter.speed;

        int finalLevel =
            selectedCharacter.level +
            pendingLevels;

        int finalSpeed =
            selectedCharacter.speed +
            (pendingLevels / 2);

        previewStatsText.text =
            "Nível: " +
            finalLevel +
            "\n\nHP: " +
            (selectedCharacter.maxHP +
            pendingHP) +
            "\nMP: " +
            (selectedCharacter.maxMP +
            pendingMP) +
            "\nATK: " +
            (selectedCharacter.attack +
            pendingAttack) +
            "\nSATK: " +
            (selectedCharacter.specialAttack +
            pendingSpecialAttack) +
            "\nSPD: " +
            finalSpeed;
    }
}