using TMPro;
using UnityEngine;

public class KeybindButton : MonoBehaviour
{
    public KeyType keyType;

    public TextMeshProUGUI keyText;

    public KeybindManager manager;

    public void StartRebind()
    {
        keyText.text = "...";

        manager.StartRebind(this);
    }

    public void UpdateText(
        string newKey)
    {
        keyText.text = newKey;
    }
}