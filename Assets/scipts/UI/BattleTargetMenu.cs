using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleTargetMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject targetButtonPrefab;

    public Transform content;

    private BattleSystem battleSystem;

    void Start()
    {
        battleSystem =
            FindFirstObjectByType
            <BattleSystem>();
    }

    public void ShowTargets(
        List<BattleUnit> targets)
    {
        gameObject.SetActive(true);

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (BattleUnit unit in targets)
        {
            if (unit == null)
                continue;

            if (unit.IsDead())
                continue;

            Debug.Log(
    "Criando botão de alvo");
            GameObject obj =
                Instantiate(
                    targetButtonPrefab,
                    content);

            TargetButton button =
                obj.GetComponent<TargetButton>();

            button.target = unit;

            TextMeshProUGUI txt =
                obj.GetComponentInChildren
                <TextMeshProUGUI>();

            txt.text =
                unit.UnitName +
                " HP: " +
                unit.currentHP +
                "/" +
                unit.MaxHP;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}