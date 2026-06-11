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

    private List<GameObject> buttons =
        new List<GameObject>();

    void Start()
    {
        battleSystem =
            FindFirstObjectByType<BattleSystem>();
    }

    public void ShowTargets(
        List<BattleUnit> targets)
    {
        gameObject.SetActive(true);

        // Esconde todos os botões existentes
        foreach (GameObject btn in buttons)
        {
            if (btn != null)
            {
                btn.SetActive(false);
            }
        }

        int index = 0;

        foreach (BattleUnit unit in targets)
        {
            if (unit == null)
                continue;

            if (unit.IsDead())
                continue;

            GameObject obj;

            // Reutiliza botão existente
            if (index < buttons.Count)
            {
                obj = buttons[index];
                obj.SetActive(true);
            }
            else
            {
                obj = Instantiate(
                    targetButtonPrefab,
                    content);

                buttons.Add(obj);
            }

            TargetButton button =
                obj.GetComponent<TargetButton>();

            button.target = unit;

            TextMeshProUGUI txt =
                obj.GetComponentInChildren<TextMeshProUGUI>();

            if (txt != null)
            {
                txt.text =
                    unit.UnitName +
                    " HP: " +
                    unit.currentHP +
                    "/" +
                    unit.MaxHP;
            }

            index++;
        }

        // Atualiza o layout imediatamente
        LayoutRebuilder.ForceRebuildLayoutImmediate(
            content.GetComponent<RectTransform>());

        Canvas.ForceUpdateCanvases();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}