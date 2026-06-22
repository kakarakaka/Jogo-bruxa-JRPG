using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    public static InteractionPromptUI Instance;

    public GameObject panel;
    public TMP_Text text;

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Show(string message)
    {
        panel.SetActive(true);
        text.text = message;
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}