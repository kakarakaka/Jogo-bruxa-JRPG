using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindButton : MonoBehaviour
{
    public InputActionReference action;

    public TextMeshProUGUI keyText;

    public void StartRebind()
    {
        action.action.Disable();

        action.action.PerformInteractiveRebinding()
            .OnComplete(op =>
            {
                op.Dispose();

                action.action.Enable();

                UpdateText();
            })
            .Start();
    }

    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        keyText.text =
            action.action.bindings[0]
            .ToDisplayString();
    }
}